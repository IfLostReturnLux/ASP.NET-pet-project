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
        //public UserModel User { get; set; }
        //public RoleModel Role { get; set; }

        [Display(Name = "Имя: ")]
        public string Name {  get; set; }
        [Display(Name = "Роль: ")]
        public string Role { get; set; }
        [Display(Name = "Логин: ")]
        public string Login { get; set; }
        [Display(Name = "Пароль: ")]
        public string Password { get; set; }

    }
}
