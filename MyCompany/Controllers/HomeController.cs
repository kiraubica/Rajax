using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;

namespace MyCompany.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        // Метод для відображення домашньої сторінки
        public IActionResult Index()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageIndex"));
        }

        // Метод для відображення сторінки з контактами
        public IActionResult Contacts()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageContacts"));
        }
    }
}
