using DemirbasTakipSistemi.Models.DataModel;
using DemirbasTakipSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace DemirbasTakipSistemi.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectRepository projectRepository = new ProjectRepository();
        private readonly ProjectProductRepository projectProductRepository = new ProjectProductRepository();
        // GET: Acount
        public ActionResult ProjectList()
        {
            return View(projectRepository.TList());
        }
        public ActionResult ProjectAdd()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult ProjectAdd(Project project)
        {
            projectRepository.TAdd(project);
            return View();
        }
        public ActionResult ProjectUpdate(string code)
        {
           
            return View(projectRepository.GetCode(code));
        }
        [HttpPost]
        public ActionResult ProjectUpdate(Project project)
        {
            projectRepository.TUpdate(project);
            return View(project);
        }
        public ActionResult Products(string code)
        {
          
            return View(projectProductRepository.List(code));
        }
        public ActionResult ProductAdd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(ProjectProduct p)
        {
            projectProductRepository.TAdd(p);
            return View();
        }
        public ActionResult ProductUpdate(string serialNumber)
        {

            return View(projectProductRepository.GetSerialNumber(serialNumber));
        }
        [HttpPost]
        public ActionResult ProductUpdate(ProjectProduct p)
        {
            projectProductRepository.TUpdate(p);
            return View(p);
        }
    }
}