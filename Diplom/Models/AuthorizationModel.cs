using System.ComponentModel.DataAnnotations;

namespace Diplom.Models
{
    public class AuthorizationModel
    {
        [Display(Name = "Логин: ")]
        [Required(ErrorMessage = "Вам нужно ввести логин!")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Пароль: ")]
        [Required(ErrorMessage = "Вам нужно ввести пароль!")]
        public string Password { get; set; }

    }
}
