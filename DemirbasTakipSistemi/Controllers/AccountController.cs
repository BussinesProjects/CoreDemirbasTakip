using DemirbasTakipSistemi.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using DemirbasTakipSistemi.Models;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using DemirbasTakipSistemi.Models.DataModel;

namespace DemirbasTakipSistemi.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountRepository accountRepository = new AccountRepository();
        Context c = new Context();

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //return redirectoaction("index",category) yerine şunu Redirect("/Category/Index"); yazsınlar.
        ///ayrica app.UseAuthentication(); app.UseAuthorization(); middlewareleri de startupa ekleyip denesinler
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {

            var user = accountRepository.getUser(username, password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return Redirect("/Product/ProductList"); //????
            }
            else
            {
                ViewBag.Error = "Lütfen bilgilerinizi kontrol ediniz.";
                return View();
            }

    }

    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Account");
    }


    //[System.Web.Mvc.OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    //public IActionResult Logout()
    //{
    //    //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    //    return RedirectToAction("Login", "Account");
    //}

}
}