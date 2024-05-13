using Diplom.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Diplom.Views.Shared;

namespace Diplom.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.User.Claims.Any())
            {
                return RedirectToAction("Index", HttpContext.User.Claims.ToList()[1].Value);
            }
            return View();
        }
        [HttpPost]
        public IActionResult LoginCheck(AuthorizationModel loginData)
        {
            if (ModelState.IsValid)
            {
                AppDbContext db = new AppDbContext();
                var serverLoginCheck = db.logindata.Select(x => x.Login == loginData.Login && x.Password == loginData.Password);

                if (serverLoginCheck.FirstOrDefault() == true)
                {
                    Console.WriteLine("Succesful login: " + loginData.Login + loginData.Password);
                    var userData = db.users.Where(x => x.Login == loginData.Login);

                    LogsController.Logs(userData.FirstOrDefault().Name + " login");

                    var claims = new List<Claim> {
                   new Claim(ClaimTypes.Name, userData.FirstOrDefault().Name),
                   new Claim("Roles", userData.FirstOrDefault().Role),
                   new Claim("Login", userData.FirstOrDefault().Login)
                   };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    Console.WriteLine(userData.FirstOrDefault().Role);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View("Index", loginData);
        }

        public IActionResult Logout()
        {
            LogsController.Logs(User.FindFirst(ClaimTypes.Name).Value.ToString() + " logout");

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
