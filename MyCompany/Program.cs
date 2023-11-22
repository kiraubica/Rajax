using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyCompany
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Точка входу програми
            // Створює конструктор хостів і збирає хост
            // Запускає програму
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            // Створює конструктор хостів за замовчуванням
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                // Налаштовує веб-хост за допомогою класу запуску
                webBuilder.UseStartup<Startup>();
            });
    }
}
