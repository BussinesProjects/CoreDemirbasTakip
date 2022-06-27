
using DemirbasTakipSistemi.Models.DataModel;
using DemirbasTakipSistemi.Models.ViewModel;
using DemirbasTakipSistemi.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;

namespace DemirbasTakipSistemi.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository = new ProductRepository();
        private readonly CategoryRepository categoryRepository = new CategoryRepository();
        private readonly PersonRepository personRepository = new PersonRepository();
        private IHostingEnvironment Environment;
        // GET: Product
        public ProductController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        public ActionResult ProductList()
        {
          
            return View(productRepository.GetAll());
        }
        public ActionResult ProductAdd()
        {
            PeopleAndCategoryViewModel pc = new PeopleAndCategoryViewModel();
            pc.People = personRepository.TList();
            pc.Categories = categoryRepository.TList();
            return View(pc);
        }
        [HttpPost]
        public ActionResult ProductAdd(Product p, List<IFormFile> postedFiles)
        {
            p.RegisterDateTime = DateTime.Now;
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                }
            }
            productRepository.TAdd(p);
            /*
            PeopleAndCategoryViewModel pc = new PeopleAndCategoryViewModel();
            pc.People = personRepository.TList();
            pc.Categories = categoryRepository.TList();
            return View(pc);*/
            return RedirectToAction("ProductList");
        }
        public ActionResult ProductUpdate(int id )
        {
            var product = productRepository.TGet(id);
            PeopleAndCategoryViewModel pc = new PeopleAndCategoryViewModel();
            pc.People = personRepository.TList();
            pc.Categories = categoryRepository.TList();
            return View(Tuple.Create<Product, PeopleAndCategoryViewModel>(product, pc));
        }

        [HttpPost]
        public ActionResult ProductUpdate(Product p)
        {
            //var product = productRepository.TGet(p.Id);
            //product.ProductSerialNumber = p.ProductSerialNumber;
            //product.CategoryID = p.CategoryID;
            //product.PersonID = p.PersonID;
            //product.ProductWarrantyDate = p.ProductWarrantyDate;
            //product.ProductBrand = p.ProductBrand;
            //product.
            productRepository.TUpdate(p);
            /*
            PeopleAndCategoryViewModel pc = new PeopleAndCategoryViewModel();
            pc.People = personRepository.TList();
            pc.Categories = categoryRepository.TList();
            return View(Tuple.Create<Product, PeopleAndCategoryViewModel>(p, pc));*/
            return RedirectToAction("ProductList");
        }
    }
}