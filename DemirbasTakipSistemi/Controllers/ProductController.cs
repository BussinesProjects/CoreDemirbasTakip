
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
        public ActionResult ProductAdd(string projCode, int prev)
        {
            PeopleAndCategoryViewModel pc = new PeopleAndCategoryViewModel();
            pc.People = personRepository.TList();
            pc.Categories = categoryRepository.TList();
            pc.Projects = projectRepository.TList();
            pc.Proj = projCode;
            pc.Prev = prev;
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
            if (p.ProjectCode != null) 
            { 
                p.ProjectIdGet = projectRepository.GetCode(p.ProjectCode).Id; 
            }
            productRepository.TAdd(p);
            //p.Category.Products.Add(p); // added recently
            //projectProductRepository.TAdd(p);
            /*
            PeopleAndCategoryViewModel pc = new PeopleAndCategoryViewModel();
            pc.People = personRepository.TList();
            pc.Categories = categoryRepository.TList();
            return View(pc);*/
            return redirectToPrev(p);
        }
        public ActionResult redirectByInt( int previous, string projCode)
        {
            if (previous == 2)
            {
                return RedirectToAction("ProductList");
            }
            else if (previous == 1)
            {
                if ( projCode == null)
                {
                    return RedirectToAction("ProductList");
                }
                else
                {
                    return RedirectToAction("Products", "Project", new { code = projCode });
                }
            }
            else
            {
                return RedirectToAction("ProjectList", "Project"); // shouldn't happen.
            }
        }

        public ActionResult redirectToPrev(Product p)
        {
            if (p.previous == 1 && p.ProjectCode != null)
            {
                return RedirectToAction("Products", "Project", new { code = p.ProjectCode, id = p.ProjectIdGet });
            }
            else if (p.previous == 2)
            {
                return RedirectToAction("ProductList");
            }
            else
            {
                return RedirectToAction("ProjectList", "Project"); // shouldn't happen.
            }
        }

        public ActionResult ProductUpdate(int id, int pre)
        {
            var product = productRepository.TGet(id);
            PeopleAndCategoryViewModel pc = new PeopleAndCategoryViewModel();
            pc.People = personRepository.TList();
            pc.Categories = categoryRepository.TList();
            pc.Projects = projectRepository.TList();
            pc.Proj = product.ProjectCode;
            pc.Prev = pre;
            return View(Tuple.Create<Product, PeopleAndCategoryViewModel>(product, pc));
        }

        [HttpPost]
        public ActionResult ProductUpdate(Product p)
        {
            p.isEnabled = true;
            productRepository.TUpdate(p);

            return redirectToPrev(p);
        }

        public ActionResult ProductInfo(int id, int pre)
        {
            var product = productRepository.TGet(id);
            PeopleAndCategoryViewModel pc = new PeopleAndCategoryViewModel();
            pc.People = personRepository.TList();
            pc.Categories = categoryRepository.TList();
            pc.Projects = projectRepository.TList();
            pc.Proj = product.ProjectCode;
            pc.Prev = pre;
            return View(Tuple.Create<Product, PeopleAndCategoryViewModel>(product, pc));
        }
        public ActionResult ProductDelete(int id, int pre)
        {
            //productRepository.TDelete( productRepository.TGet(id));
            Product product = productRepository.TGet(id);
            product.isEnabled = false;
            productRepository.TUpdate(product);
            product.previous = pre;
            //projectProductRepository.TUpdate(product);

            return redirectToPrev(product);
        }
    }
}