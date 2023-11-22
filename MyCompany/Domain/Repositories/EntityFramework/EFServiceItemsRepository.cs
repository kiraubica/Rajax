using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;

namespace MyCompany.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository : IServiceItemsRepository
    {
        private readonly AppDbContext context;

        public EFServiceItemsRepository(AppDbContext context)
        {
            this.context = context;
        }

        // Метод для отримання всіх елементів послуг
        public IQueryable<ServiceItem> GetServiceItems()
        {
            return context.ServiceItems;
        }

        // Метод для отримання елементу послуги за його ідентифікатором
        public ServiceItem GetServiceItemById(Guid id)
        {
            return context.ServiceItems.FirstOrDefault(x => x.Id == id);
        }

        // Метод для збереження елементу послуги
        public void SaveServiceItem(ServiceItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        // Метод для видалення елементу послуги за його ідентифікатором
        public void DeleteServiceItems(Guid id)
        {
            context.ServiceItems.Remove(new ServiceItem { Id = id });
            context.SaveChanges();
        }
    }
}
