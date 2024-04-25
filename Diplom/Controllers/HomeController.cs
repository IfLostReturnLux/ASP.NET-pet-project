using Diplom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Diplom.AppDbContext;
using System.Linq;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Diplom.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _dbContext = new AppDbContext();
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult adminPage()
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
        [Authorize(Roles = "user")]
        public IActionResult userPage()
        {
            return View();
        }
        
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
