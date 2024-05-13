using System.ComponentModel.DataAnnotations;

namespace Diplom.Models
{
    public class UserModel
    {
        [Display(Name = "Имя: ")]
        [Required(ErrorMessage = "Вам нужно ввести Имя!")]
        public string Name { get; set; }

        [Display(Name = "Роль: ")]
        [Required(ErrorMessage = "Вам нужно ввести Роль!")]
        public string Role { get; set; }

        [Display(Name = "Логин: ")]
        [Required(ErrorMessage = "Вам нужно ввести Логин!")]
        public string Login { get; set; }

        [Display(Name = "Пароль: ")]
        [Required(ErrorMessage = "Вам нужно ввести Пароль!")]
        public string Password { get; set; }
    }
}
