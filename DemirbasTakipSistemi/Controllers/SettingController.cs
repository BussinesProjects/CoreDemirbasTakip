using DemirbasTakipSistemi.Models.DataModel;
using DemirbasTakipSistemi.Repositories;
<<<<<<< Updated upstream
=======
using Microsoft.AspNetCore.Http;
>>>>>>> Stashed changes
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemirbasTakipSistemi.Controllers
{
    public class SettingController : Controller
    {
<<<<<<< Updated upstream
        AccountRepository accountRepository = new AccountRepository();
=======
        const string SessionName = "_Name";// have to change SessionController as well if changed

        private AccountRepository accountRepository = new AccountRepository();

>>>>>>> Stashed changes
        public IActionResult Index()
        {
            var list = accountRepository.getNotAdmin();

            return View(list);
        }
        public IActionResult UsernamePasswordUpdate()
        {
            return View();
        }
<<<<<<< Updated upstream
        public IActionResult UserUpdate(int id)
        {
            return View(accountRepository.TGet(id));
        }

        [HttpGet]
        public IActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserAdd(Login login)
        {
            return View();
=======

        //[HttpGet]
        //public ActionResult UsernamePasswordUpdate()
        //{

        //    return View();
        //}

        [HttpPost]
        public ActionResult UsernamePasswordUpdate(string prevPass, string newUserName, string newPass, string newPass2)
        {
            bool nameChange = false;
            bool passwordChange = false;
            string name = HttpContext.Session.GetString(SessionName);
            var person = accountRepository.getUser( name, prevPass);
            if (person != null && person.Password == prevPass) // person var, geçerli
            {
                // username kontrol ediliyor
                if (newUserName != person.Username) // username geçerli
                {
                    if (! (newUserName == "" || newUserName == null)) // username geçersiz
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
                    else if ( !(newPass == "" || newPass == null)) // password değişti
                    {
                        passwordChange = true;
                    }
                }
            }
            else if (prevPass != null)
            {
                ViewBag.Error = "Şifre geçersiz! Kullanıcının şifresi bu değil.";
            }

            // if there is anything changed,
            if (passwordChange || nameChange)
            {
                if (nameChange) { 
                    person.Username = newUserName;
                    HttpContext.Session.SetString(SessionName, newUserName);
                }
                if (passwordChange) { person.Password = newPass; }
                accountRepository.TUpdate(person);
                return RedirectToAction("ProductList", "Product"); // change to options or sth later
            }// if nothing has been changed,
            else if ((ViewBag.Error== null || ViewBag.Error == "") && prevPass != null)
            {
                ViewBag.Error = "Girilen yeni kullanıcı adı veya yeni şifre hatalı!";
                return View();
            }
            else { 
                return View();
            }
>>>>>>> Stashed changes
        }
        public IActionResult UserDelete()
        {
            return View();
        }

    }
}
