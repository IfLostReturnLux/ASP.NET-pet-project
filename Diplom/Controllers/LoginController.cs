using Diplom.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Diplom.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.User.Claims.Any())
            {
                return RedirectToAction(HttpContext.User.Claims.ToList()[1].Value + "Page", "Home");
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

                Console.WriteLine($"{loginData.Login}: {loginData.Password} -{serverLoginCheck.ElementType.Name}");

                if (serverLoginCheck.FirstOrDefault() == true)
                {

                    Console.WriteLine("Succesful login: " + loginData.Login + loginData.Password);
                    var userData = db.users.Where(x => x.Login == loginData.Login);

                    var claims = new List<Claim> {
                   new Claim(ClaimTypes.Name, userData.FirstOrDefault().Login),
                   new Claim(ClaimTypes.Role, userData.FirstOrDefault().Role)
                   };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction(userData.FirstOrDefault().Role + "Page", "Home");
                }
            }

            return View("Index", loginData);
        }
    }
}
