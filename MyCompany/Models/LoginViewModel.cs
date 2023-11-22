using System.ComponentModel.DataAnnotations;

namespace MyCompany.Models
{
    public class LoginViewModel
    {
        // Властивість для ім'я користувача
        [Required]
        [Display(Name = "Логін")]
        public string UserName { get; set; }

        // Властивість для пароля користувача
        [Required]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        // Властивість для запам'ятовування користувача
        [Display(Name = "Запам'ятати мене?")]
        public bool RememberMe { get; set; }
    }
}
