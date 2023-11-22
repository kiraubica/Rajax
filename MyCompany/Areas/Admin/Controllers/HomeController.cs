using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;

namespace MyCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        // Метод для відображення головної сторінки адміністратора
        public IActionResult Index()
        {
            // Отримуємо список послуг з використанням DataManager і передаємо його на сторінку
            return View(dataManager.ServiceItems.GetServiceItems());
        }
    }
}
