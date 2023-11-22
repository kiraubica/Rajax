using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;

namespace MyCompany.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataManager dataManager;

        public ServicesController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        // Метод для відображення списку послуг
        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                // Якщо передано id, відображаємо окрему сторінку з деталями послуги
                return View("Show", dataManager.ServiceItems.GetServiceItemById(id));
            }

            // Встановлюємо ViewBag.TextField для передачі текстового поля на сторінку
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageServices");

            // Відображаємо список всіх послуг
            return View(dataManager.ServiceItems.GetServiceItems());
        }
    }
}
