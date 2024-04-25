using System.ComponentModel.DataAnnotations;
using static Diplom.AppDbContext;

namespace Diplom.Models
{
    public class AdminPageModel
    {
        //Get
        public List<string> RoleList { get; set; }
        public List<UserData> UsersList { get; set; }


        //Post
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
