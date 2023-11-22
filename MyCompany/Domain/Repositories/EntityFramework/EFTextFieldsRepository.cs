using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using System.Reflection.Metadata.Ecma335;

namespace MyCompany.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext context;

        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }

        // Метод для отримання всіх текстових полів
        public IQueryable<TextField> GetTextFields()
        {
            return context.TextFields;
        }

        // Метод для отримання текстового поля за його ідентифікатором
        public TextField GetTextFieldById(Guid id)
        {
            return context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        // Метод для отримання текстового поля за його кодовим словом
        public TextField GetTextFieldByCodeWord(string codeword)
        {
            return context.TextFields.FirstOrDefault(x => x.CodeWord == codeword);
        }

        // Метод для збереження текстового поля
        public void SaveTextField(TextField entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        // Метод для видалення текстового поля за його ідентифікатором
        public void DeleteTextField(Guid id)
        {
            context.TextFields.Remove(new TextField { Id = id });
            context.SaveChanges();
        }
    }
}
