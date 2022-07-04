using DemirbasTakipSistemi.Models.DataModel;
using DemirbasTakipSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

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
            if ( project.ProjectCode != null && projectRepository.GetCode(project.ProjectCode) == null)
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
        public ActionResult ProjectDelete(string code)
        {
            Project project = projectRepository.GetCode(code);
            project.isEnabled = false;
            projectRepository.TUpdate(project);

            return RedirectToAction("ProjectList");

        }




        public ActionResult Products(string code)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.listProjectsOfCode = projectProductRepository.List(code);
            mymodel.projectCode = code;
            return View(mymodel);

            //return View(projectProductRepository.List(code));
        }
        public ActionResult ProductAdd( string code)
        {
            Project project = projectRepository.GetCode(code);
            return View( project);
        }
        [HttpPost]
        public ActionResult ProductAdd(ProjectProduct p)
        {
            // check if the project code exists
            bool foundProject = false;
            bool existsAlready = false;
            if ( projectRepository.GetCode(p.ProjectCode) != null)
            {
                foundProject = true;
            }
            foreach ( ProjectProduct product in projectProductRepository.GetAll())
            {
                if ( product.ProductSerialNumber.Equals( p.ProductSerialNumber))
                {
                    existsAlready = true;
                }
            }


            if (foundProject && !existsAlready) // the project code is a valid project code
            {
                p.Project = projectRepository.GetCode(p.ProjectCode);
                p.isEnabled = true;
                projectProductRepository.TAdd(p);
                //return View(projectProductRepository.List(p.ProjectCode));
                return Products(p.ProjectCode); //???
            }
            else if (foundProject && existsAlready)
            {
                return View( projectRepository.GetCode( p.ProjectCode));
            }
            else // should not happen, but just in case
            {
                return RedirectToAction("ProjectList");
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