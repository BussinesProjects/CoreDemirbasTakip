
using DemirbasTakipSistemi.Interface;
using DemirbasTakipSistemi.Models;
using DemirbasTakipSistemi.Models.DataModel;
using DemirbasTakipSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemirbasTakipSistemi.Controllers
{
    public class CategoryController : Controller
    {
        
        private readonly CategoryRepository categoryRepository = new CategoryRepository();
        // GET: Category
       
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {

            return View();
        }
        public ActionResult CategoryUpdate()
        {
            return View();
        }
        public ActionResult CategoryList()
        {
            var list = categoryRepository.TList();
            return View();
        }
        public ActionResult CategoryDelete()
        {
            return View();
        }
    }
}