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
            if ( project.ProjectCode != null)
            {
                project.isEnabled = true;
                projectRepository.TAdd(project);
                return RedirectToAction("ProjectList");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult ProductAdd(ProjectProduct p)
        {
            if ( p.ProjectCode != null)
            {
                p.isEnabled = true;
                projectProductRepository.TAdd(p);
                return RedirectToAction("ProjectList");
            }
            else
            {
                return View();
            }
        }
        public ActionResult ProjectUpdate(string code)
        {
           
            return View(projectRepository.GetCode(code));
        }
        [HttpPost]
        public ActionResult ProjectUpdate(Project project)
        {
            projectRepository.TUpdate(project);
            return RedirectToAction("ProjectList");
        }
        public ActionResult Products(string code)
        {
          
            return View(projectProductRepository.List(code));
        }
        public ActionResult ProductAdd()
        {

            return View();
        }
        public ActionResult ProductUpdate(string serialNumber)
        {

            return View(projectProductRepository.GetSerialNumber(serialNumber));
        }
        [HttpPost]
        public ActionResult ProductUpdate(ProjectProduct p)
        {
            projectProductRepository.TUpdate(p);//productRepository.TDelete( productRepository.TGet(id));
            
            return RedirectToAction("ProjectList");

        }

        public ActionResult ProductDelete(string IDcode)
        {
            ProjectProduct project = projectProductRepository.GetSerialNumber(IDcode);
            project.isEnabled = false;
            projectProductRepository.TUpdate(project);

            return RedirectToAction("ProjectList");

        }
    }
}