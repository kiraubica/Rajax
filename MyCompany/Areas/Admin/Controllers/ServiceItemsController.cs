using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Service;

namespace MyCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceItemsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ServiceItemsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        // Метод для редагування послуги
        public IActionResult Edit(Guid id)
        {
            // Отримуємо послугу за її ідентифікатором або створюємо нову, якщо ідентифікатор є за замовчуванням
            var entity = id == default ? new ServiceItem() : dataManager.ServiceItems.GetServiceItemById(id);
            return View(entity);
        }

        // Метод для збереження змін після редагування послуги
        [HttpPost]
        public IActionResult Edit(ServiceItem model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    // Збереження зображення для заголовку послуги
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                dataManager.ServiceItems.SaveServiceItem(model);
                // Перенаправлення на головну сторінку адміністратора після збереження
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        // Метод для видалення послуги
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.ServiceItems.DeleteServiceItems(id);
            // Перенаправлення на головну сторінку адміністратора після видалення
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
