using MyCompany.Domain.Repositories.Abstract;

namespace MyCompany.Domain
{
    public class DataManager
    {
        // Властивість для доступу до репозиторію текстових полів
        public ITextFieldsRepository TextFields { get; set; }

        // Властивість для доступу до репозиторію елементів сервісу
        public IServiceItemsRepository ServiceItems { get; set; }

        // Конструктор класу DataManager, який приймає репозиторії в якості залежностей
        public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository)
        {
            // Ініціалізація властивостей TextFields і ServiceItems залежностями
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;
        }
    }
}
