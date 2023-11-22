using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;

namespace MyCompany.Models.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly DataManager dataManager;

        public SidebarViewComponent(DataManager dataManager)
        {
            // Ініціалізація залежності DataManager через конструктор
            this.dataManager = dataManager;
        }

        // Асинхронний метод для виклику View Component
        public Task<IViewComponentResult> InvokeAsync()
        {
            // Повертаємо результат у вигляді IViewComponentResult, використовуючи представлення "Default" і дані отримані з DataManager
            return Task.FromResult((IViewComponentResult)View("Default", dataManager.ServiceItems.GetServiceItems()));
        }
    }
}
