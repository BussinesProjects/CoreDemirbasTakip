using DemirbasTakipSistemi.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DemirbasTakipSistemi.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountRepository accountRepository = new AccountRepository();
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            var user=accountRepository.getUser(username, password);
            if(user != null)
            {
                return RedirectToAction("ProductList", "Product");
            }
            else
            {
                ViewBag.Error = "Lütfen bilgilerinizi kontrol ediniz.";
                return View();
            }

        }
        public IActionResult Logout()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

    }
}
