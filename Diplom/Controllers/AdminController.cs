using Diplom.Models;
using Diplom.Views.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Diplom.AppDbContext;

namespace Diplom.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AdminController()
        {
            _dbContext = new AppDbContext();
        }

        public IActionResult Index()
        {
            var roles = _dbContext.rolelist;
            List<string> rolesList = roles.Select(role => role.Name).ToList();

            var users = _dbContext.users;
            List<UserData> usersList = users.ToList();

            AdminPageModel model = new AdminPageModel();
            model.RoleList = rolesList;
            model.UsersList = usersList;
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateNewUser(AdminPageModel pageModel)
        {
            var isLoginBusy = _dbContext.logindata.Select(x => x.Login == pageModel.Login).FirstOrDefault();


            if (!isLoginBusy)
            {
                LoginData loginData = new LoginData();
                loginData.Login = pageModel.Login;
                loginData.Password = pageModel.Password;
                _dbContext.logindata.Add(loginData);
                _dbContext.SaveChanges();

                var newUser = _dbContext.users.Where(x => x.Login == pageModel.Login).FirstOrDefault();
                newUser.Name = pageModel.Name;

                LogsController.Logs($"Was creating new user with name:{pageModel.Name}, login:{pageModel.Login}");

                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult CreateNewRole(AdminPageModel pageModel)
        {
            var isRoleExist = _dbContext.rolelist.Select(x=> x.Name == pageModel.Role).FirstOrDefault();

            if (!isRoleExist)
            {
                Role role = new Role();
                role.Name = pageModel.Role;


                LogsController.Logs($"Was creating new role with name:{pageModel.Role}");

                _dbContext.rolelist.Add(role);
                _dbContext.SaveChanges();
            }


            return RedirectToAction("Index");
        }
    }
}