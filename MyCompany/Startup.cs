using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain;
using MyCompany.Domain.Repositories.Abstract;
using MyCompany.Domain.Repositories.EntityFramework;
using MyCompany.Service;

namespace MyCompany
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            //підключаємо конфіг із appsettings.json
            Configuration.Bind("Project", new Config());

            //підключаємо потрібний функціонал додатку в виді сервісів
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<DataManager>();

            //підключаємо контекст БД
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            //налаштовуємо identity систему
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //налаштовуємо authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            //налаштовуємо політику авторизації для Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            //додаємо підтримку контролерів та видів (MVC)
            services.AddControllersWithViews(x =>
                {
                    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
                })
                //ставимо сумісність з останньою версією фрейсворка
                .SetCompatibilityVersion(CompatibilityVersion.Latest).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) 
                app.UseDeveloperExceptionPage();

            //підключаємо підтримку статичних файлів в додатку(css, js і т.д.)
            app.UseStaticFiles();

            //підключаємо систему марштрутизації
            app.UseRouting();

            //підключаємо аутентифікацію та авторизацію
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
           
            //реєструємо потрібні нам маршрути(ендпоінти)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
