using System.ComponentModel.DataAnnotations;

namespace Diplom.Models
{
    public class RoleModel
    {
        [Display(Name = "Роль: ")]
        [Required(ErrorMessage = "Вам нужно ввести Роль!")]
        public string RoleName { get; set; }
    }
}
