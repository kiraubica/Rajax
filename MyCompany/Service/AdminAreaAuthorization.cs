using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace MyCompany.Service
{
    public class AdminAreaAuthorization : IControllerModelConvention
    {
        private readonly string area;
        private readonly string policy;

        public AdminAreaAuthorization(string area, string policy)
        {
            this.area = area;
            this.policy = policy;
        }

        // Метод Apply викликається для кожного контролера і застосовує авторизацію для контролерів в певній області
        public void Apply(ControllerModel controller)
        {
            // Перевірка, чи контролер має атрибут AreaAttribute з відповідним значенням області
            if (controller.Attributes.Any(a =>
                a is AreaAttribute && (a as AreaAttribute).RouteValue.Equals(area, StringComparison.OrdinalIgnoreCase))
            || controller.RouteValues.Any(r =>
                r.Key.Equals("area", StringComparison.OrdinalIgnoreCase) && r.Value.Equals(area, StringComparison.OrdinalIgnoreCase)))
            {
                // Додавання фільтра авторизації до контролера
                controller.Filters.Add(new AuthorizeFilter(policy));
            }
        }
    }
}
