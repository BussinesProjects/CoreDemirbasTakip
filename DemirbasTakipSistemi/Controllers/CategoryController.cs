
using DemirbasTakipSistemi.Interface;
using DemirbasTakipSistemi.Models;
using DemirbasTakipSistemi.Models.DataModel;
using DemirbasTakipSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DemirbasTakipSistemi.Controllers
{
    public class CategoryController : Controller
    {
        
        private readonly CategoryRepository categoryRepository = new CategoryRepository();
        // GET: Category

        public ActionResult CategoryList()
        {
            var list = categoryRepository.TList();
            foreach (Category c in list)
            {
                c.ProductCount = c.Products.Where(x => x.isEnabled).Count();
            }

            return View(list);
        }

        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {
            category.isEnabled = true;
            category.ProductCount = 0;
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
            c.isEnabled = true;
            c.ProductCount = c.Products.Where(x => x.isEnabled).Count();
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