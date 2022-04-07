
using Microsoft.AspNetCore.Mvc;


namespace DemirbasTakipSistemi.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductList()
        {
            return View();
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