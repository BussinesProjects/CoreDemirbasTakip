
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

        private readonly ProjectRepository projectRepository = new ProjectRepository();
        //private readonly ProjectProductRepository projectProductRepository = new ProjectProductRepository();

        //private readonly ProjectProductRepository projectProductRepository = new ProjectProductRepository();
        private IHostingEnvironment Environment;
        // GET: Product
        public ProductController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        public ActionResult ProductList()
        {
            //dynamic mymodel = new ExpandoObject();
            //mymodel.List<Product> = productRepository.GetAll();
            //mymodel.List<ProjectProduct> = projectProductRepository.GetAll();
            //return View(mymodel);

            return View(productRepository.GetAll());
        }
        //public ActionResult ProductAdd()
        //{
        //    PeopleAndCategoryViewModel pc = new PeopleAndCategoryViewModel();
        //    pc.People = personRepository.TList();
        //    pc.Categories = categoryRepository.TList();
        //    pc.Projects = projectRepository.TList();
        //    pc.Proj = "";
        //    return View(pc);
        //}
        public ActionResult ProductAdd(string code)
        {
            PeopleAndCategoryViewModel pc = new PeopleAndCategoryViewModel();
            pc.People = personRepository.TList();
            pc.Categories = categoryRepository.TList();
            pc.Projects = projectRepository.TList();
            pc.Proj = code;
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
            p.isEnabled = true;
            productRepository.TAdd(p);
            //p.Category.Products.Add(p); // added recently
            //projectProductRepository.TAdd(p);
            /*
            PeopleAndCategoryViewModel pc = new PeopleAndCategoryViewModel();
            pc.People = personRepository.TList();
            pc.Categories = categoryRepository.TList();
            return View(pc);*/
            if (p.ProjectCode == null || p.ProjectCode.Equals(""))
            {
                return RedirectToAction("ProductList");
            }
            else
            {
                return RedirectToAction("Products", "Project", new { code = p.ProjectCode });
            }
        }
        public ActionResult ProductUpdate(int id)
        {
            var product = productRepository.TGet(id);
            PeopleAndCategoryViewModel pc = new PeopleAndCategoryViewModel();
            pc.People = personRepository.TList();
            pc.Categories = categoryRepository.TList();
            pc.Projects = projectRepository.TList();
            pc.Proj = product.ProjectCode;
            return View(Tuple.Create<Product, PeopleAndCategoryViewModel>(product, pc));
        }

        [HttpPost]
        public ActionResult ProductUpdate(Product p)
        {
            //Product product = productRepository.TGet(p.Id);
            //product.ProductSerialNumber = p.ProductSerialNumber;
            //product.CategoryID = p.CategoryID;
            //product.PersonID = p.PersonID;
            //p.ProductWarrantyStartDate= product.ProductWarrantyStartDate;
            //p.ProductWarrantyFinishDate= product.ProductWarrantyFinishDate;
            //p.RegisterDateTime = product.RegisterDateTime;
            //product.ProductBrand = p.ProductBrand;
            //product.
            p.isEnabled = true;
            productRepository.TUpdate(p);
            //projectProductRepository.TUpdate(p);
            /*
            PeopleAndCategoryViewModel pc = new PeopleAndCategoryViewModel();
            pc.People = personRepository.TList();
            pc.Categories = categoryRepository.TList();
            return View(Tuple.Create<Product, PeopleAndCategoryViewModel>(p, pc));*/

            if (p.ProjectCode == null || p.ProjectCode.Equals(""))
            {
                return RedirectToAction("ProductList");
            }
            else
            {
                return RedirectToAction("Products", "Project", new { code = p.ProjectCode });
            }
        }

        public ActionResult ProductDelete(int id)
        {
            //productRepository.TDelete( productRepository.TGet(id));
            Product product = productRepository.TGet(id);
            product.isEnabled = false;
            productRepository.TUpdate(product);
            //projectProductRepository.TUpdate(product);

            if (product.ProjectCode == null || product.ProjectCode.Equals(""))
            {
                return RedirectToAction("ProductList");
            }
            else
            {
                return RedirectToAction("Products", "Project", new { code = product.ProjectCode });
            }
        }
    }
}