using MyCompany.Domain.Entities;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface IServiceItemsRepository
    {
        // Метод для отримання всіх елементів сервісу
        IQueryable<ServiceItem> GetServiceItems();

        // Метод для отримання елемента сервісу за його ідентифікатором
        ServiceItem GetServiceItemById(Guid id);

        // Метод для збереження елемента сервісу
        void SaveServiceItem(ServiceItem entity);

        // Метод для видалення елемента сервісу за його ідентифікатором
        void DeleteServiceItems(Guid id);
    }
}
