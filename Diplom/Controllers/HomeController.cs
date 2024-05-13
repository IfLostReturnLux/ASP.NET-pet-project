using Diplom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Diplom.Views.Shared;

namespace Diplom.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _dbContext = new AppDbContext();
            _webHostEnvironment = webHostEnvironment;
            LogsController.Path = _webHostEnvironment.ContentRootPath + @"\logs.txt";
        }
        
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                HomePageModel model = new HomePageModel();
                string[] roles = User.FindFirst("Roles").Value.Split(',');
                foreach (string role in roles) 
                {
                    if (role == "admin")
                    {
                        model.Buttons.Add("Админ-панель","/" + role);
                    }
                }
                return View("AuthorizedHome", model);
            }
            else
            {
                return View();
            }
        }
        [Authorize]
        public IActionResult Profile ()
        {
            UserModel model = new UserModel();
            model.Name = User.FindFirst(ClaimTypes.Name).Value.ToString();
            model.Role = User.FindFirst("Roles").Value.ToString();
            model.Login = User.FindFirst("Login").Value.ToString();
            
            return View(model);
        }


        [Authorize]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
