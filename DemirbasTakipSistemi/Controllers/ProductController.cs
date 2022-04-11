
using DemirbasTakipSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace DemirbasTakipSistemi.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository = new ProductRepository();
        // GET: Product
        public ActionResult ProductList()
        {
            return View(productRepository.TList());
        }
        public ActionResult ProductAdd()
        {
            return View();
        }
        public ActionResult ProductUpdate()
        {
            return View();
        }
    }
}