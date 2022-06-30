
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

        public ActionResult CategoryList()
        {
            var list = categoryRepository.TList();
            
            return View(list);
        }

        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(string name)
        {
            Category category = new Category();
            category.CategoryName = name;
            category.isEnabled = true;
            categoryRepository.TAdd(category);

            return RedirectToAction("CategoryList");
        }
        //[HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            return View(categoryRepository.TGet(id));
        }

        [HttpPost]
        public ActionResult CategoryUpdate(Category c)
        {
            categoryRepository.TUpdate(c);
            return RedirectToAction("CategoryList");
        }
        public ActionResult CategoryDelete( int id)
        {
            //categoryRepository.TDelete(categoryRepository.TGet(id));
            Category category = categoryRepository.TGet(id);
            category.isEnabled = false;
            categoryRepository.TUpdate(category);

            return RedirectToAction("CategoryList");
        }
    }
}