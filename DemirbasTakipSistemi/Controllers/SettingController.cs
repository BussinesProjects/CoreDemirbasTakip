using DemirbasTakipSistemi.Models.DataModel;
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
        AccountRepository accountRepository = new AccountRepository();
        public IActionResult Index()
        {
            var list = accountRepository.getNotAdmin();

            return View(list);
        }
        public IActionResult UsernamePasswordUpdate()
        {
            return View();
        }
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
        }
        public IActionResult UserDelete()
        {
            return View();
        }

    }
}
