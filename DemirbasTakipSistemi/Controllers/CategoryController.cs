﻿
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
        public ActionResult CategoryAdd(string name)
        {
            Category category = new Category();
            category.CategoryName = name;
            categoryRepository.TAdd(category);

            return View(category);
        }
        [HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            var c = categoryRepository.TGet(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult CategoryUpdate(Category c)
        {
            categoryRepository.TUpdate(c);
            return View(c);
        }
        public ActionResult CategoryList()
        {
            var list = categoryRepository.TList();
            return View(list);
        }
        public ActionResult CategoryDelete()
        {
            return View();
        }
    }
}