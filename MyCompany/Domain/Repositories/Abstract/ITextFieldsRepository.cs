using MyCompany.Domain.Entities;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface ITextFieldsRepository
    {
        // Метод для отримання всіх текстових полів
        IQueryable<TextField> GetTextFields();

        // Метод для отримання текстового поля за його ідентифікатором
        TextField GetTextFieldById(Guid id);

        // Метод для отримання текстового поля за його кодовим словом
        TextField GetTextFieldByCodeWord(string codeword);

        // Метод для збереження текстового поля
        void SaveTextField(TextField entity);

        // Метод для видалення текстового поля за його ідентифікатором
        void DeleteTextField(Guid id);
    }
}
