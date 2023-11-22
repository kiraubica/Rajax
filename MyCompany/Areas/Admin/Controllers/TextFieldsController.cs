using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Service;

namespace MyCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFieldsController : Controller
    {
        private readonly DataManager dataManager;

        public TextFieldsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        // Метод для редагування текстового поля за його кодовим словом
        public IActionResult Edit(string codeWord)
        {
            // Отримуємо текстове поле за його кодовим словом
            var entity = dataManager.TextFields.GetTextFieldByCodeWord(codeWord);
            return View(entity);
        }

        // Метод для збереження змін після редагування текстового поля
        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            if (ModelState.IsValid)
            {
                dataManager.TextFields.SaveTextField(model);
                // Перенаправлення на головну сторінку адміністратора після збереження
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
    }
}
