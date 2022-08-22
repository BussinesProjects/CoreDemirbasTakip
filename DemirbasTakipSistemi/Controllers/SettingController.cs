using DemirbasTakipSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemirbasTakipSistemi.Controllers
{
    public class SettingController : Controller
    {
        private AccountRepository accountRepository = new AccountRepository();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UsernamePasswordUpdate()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UsernamePasswordUpdate(string prevPass, string newUserName, string newPass, string newPass2, int id)
        {
            bool nameChange = false;
            bool passwordChange = false;
            var person = accountRepository.TGet(id);
            if (person != null && person.Password == prevPass) // person var, geçerli
            {
                // username kontrol ediliyor
                if (newUserName != person.Username) // username değiştirilmiş
                {
                    if (newUserName == "" || newUserName == null) // username geçersiz
                    {
                        ViewBag.Error = "Girilen yeni kullanıcı adı hatalı!";
                        return View();
                    }
                    else // username geçerli
                    {
                        nameChange = true;
                    }
                }
                // password kontrol ediliyor
                if (newPass == prevPass) // password öncekiyle aynı
                {

                    ViewBag.Error = "Şifre önceki şifreyle aynı olamaz! Farklı bir şifre oluşturunuz.";
                }
                else  // yeni password öncekiyle aynı değil
                {
                    if (newPass != newPass2) // yeni passwordlar uyuşmuyor
                    {
                        ViewBag.Error = "İki yeni şifre uyuşmuyor!";
                    }
                    else // password değişti
                    {
                        passwordChange = true;
                    }
                }
            }
            else
            {
                ViewBag.Error = "Şifre geçersiz! Kullanıcının şifresi bu değil.";
            }

            // if there is anything changed,
            if (passwordChange || nameChange)
            {
                if (nameChange) { person.Username = newUserName; }
                if (passwordChange) { person.Password = newPass; }
                return RedirectToAction("ProductList", "Product"); // change to options or sth later
            }
            else
            {
                return View();
            }
        }
    }
}
