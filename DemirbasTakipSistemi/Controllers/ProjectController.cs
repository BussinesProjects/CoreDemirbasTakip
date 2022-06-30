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
        public ActionResult ProjectDelete(string ProjectCode)
        {
            Project project = projectRepository.GetCode(ProjectCode);
            project.isEnabled = false;
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
        [HttpPost]
        public ActionResult ProductAdd(ProjectProduct p)
        {
            // check if the project code exists
            bool found = false;
            foreach (ProjectProduct project in projectProductRepository.List( p.ProjectCode))
            {
                if (project.ProjectCode.Equals(p.ProjectCode))// should be true for all
                {
                    found = true;
                }
            }
            if (found) // the project code is a valid project code
            {
                p.isEnabled = true;
                projectProductRepository.TAdd(p);
                return View(projectProductRepository.List(p.ProjectCode));
            }
            else
            {
                return View();
            }
        }
        public ActionResult ProductUpdate(string serialNumber) 
        {

            return View(projectProductRepository.GetSerialNumber(serialNumber));
        }
        [HttpPost]
        public ActionResult ProductUpdate(ProjectProduct p)
        {
            projectProductRepository.TUpdate(p);
            
            return RedirectToAction("ProjectList");

        }

        public ActionResult ProductDelete(string serialNumber)
        {
            ProjectProduct product = projectProductRepository.GetSerialNumber(serialNumber);
            product.isEnabled = false;
            projectProductRepository.TUpdate(product);

            return RedirectToAction("ProjectList");

        }
    }
}