
using DemirbasTakipSistemi.Models.DataModel;
using DemirbasTakipSistemi.Models.ViewModel;
using DemirbasTakipSistemi.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO; using Microsoft.AspNetCore.Hosting;

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
        //private readonly IWebHostEnvironment webHostEnvironment;
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
        public ActionResult ProductAdd(string code, int prev)
        {
            PeopleAndCategoryViewModel pc = new PeopleAndCategoryViewModel();
            pc.People = personRepository.TList();
            pc.Categories = categoryRepository.TList();
            pc.Projects = projectRepository.TList();
            pc.Proj = code;
            pc.Prev = prev;
            return View(pc);
        }
        [HttpPost]
        //public ActionResult ProductAdd(Product p, List<IFormFile> postedFiles)
        public ActionResult ProductAdd(ProductViewModel p)
        {
            p.product.RegisterDateTime = DateTime.Now;
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //List<string> uploadedFiles = new List<string>();
            //foreach (IFormFile postedFile in postedFiles)
            //{
            //    string fileName = Path.GetFileName(postedFile.FileName);
            //    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            //    {
            //        postedFile.CopyTo(stream);
            //        uploadedFiles.Add(fileName);
            //        ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
            //    }
            //}

            string uniqueFileName = UploadedFile(p);
            p.product.ProductPicture = uniqueFileName;
            p.product.isEnabled = true;
            productRepository.TAdd(p.product);
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

        public ActionResult redirectToPrev(ProductViewModel p)
        {
            if (p.product.previous == 2)
            {
                return RedirectToAction("ProductList");
            }
            else if (p.product.previous == 1)
            {
                return RedirectToAction("Products", "Project", new { code = p.product.ProjectCode });
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
            ProductViewModel prodView = new ProductViewModel();
            prodView.product = product;
            return View(Tuple.Create<ProductViewModel, PeopleAndCategoryViewModel>(prodView, pc));
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
            ProductViewModel prodView = new ProductViewModel();
            prodView.product = product;
            //if (product.ProductPicture != null || product.ProductPicture != "")
            //{
            //    prodView.ProductImage = product.ProductPicture
            //}
            return View(Tuple.Create<ProductViewModel, PeopleAndCategoryViewModel>(prodView, pc));
        }

        [HttpPost]
        public ActionResult ProductUpdate(ProductViewModel p)
        {

            p.product.isEnabled = true;
            string uniqueFileName = UploadedFile(p);
            p.product.ProductPicture = uniqueFileName;
            productRepository.TUpdate(p.product);

            return redirectToPrev(p);
        }

        public ActionResult ProductDelete(int id, int pre)
        {
            //productRepository.TDelete( productRepository.TGet(id));
            Product product = productRepository.TGet(id);
            product.isEnabled = false;
            productRepository.TUpdate(product);
            product.previous = pre;
            //projectProductRepository.TUpdate(product);

            ProductViewModel prodView = new ProductViewModel();
            prodView.product = product;
            return redirectToPrev(prodView);
        }



        private string UploadedFile(ProductViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProductImage != null)
            {
                string uploadsFolder = Path.Combine(Environment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProductImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProductImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}