using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemirbasTakipSistemi.Controllers
{
    public class SettingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PasswordUpdate()
        {
            return View();
        }

    }
}
