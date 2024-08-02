using System.ComponentModel.DataAnnotations;

namespace Diplom.Models
{
    public class AuthorizationModel
    {
        [Display(Name = "Логин: ")]
        [MaxLength(32, ErrorMessage = "Длина должна быть не более 32 символов")]
        [MinLength(3, ErrorMessage = "Длина должна быть не менее 3 символов")]
        [Required(ErrorMessage = "Вам нужно ввести логин!")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Пароль: ")]
        [MaxLength(32, ErrorMessage = "Длина должна быть не более 32 символов")]
        [MinLength(4, ErrorMessage = "Длина должна быть не менее 4 символов")]
        [Required(ErrorMessage = "Вам нужно ввести пароль!")]
        public string Password { get; set; }

    }
}
