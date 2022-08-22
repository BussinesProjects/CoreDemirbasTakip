using DemirbasTakipSistemi.Models.DataModel;
using DemirbasTakipSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace DemirbasTakipSistemi.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectRepository projectRepository = new ProjectRepository();
        private readonly ProductRepository productRepository = new ProductRepository();

        //private readonly ProjectProductRepository projectProductRepository = new ProjectProductRepository();
        // GET: Acount
        public ActionResult ProjectList()
        {

            var list = projectRepository.TList();
            foreach (Project proj in list)
            {
                proj.ProjectCount = productRepository.List( proj.ProjectCode).Where(x => x.isEnabled).Count();
            }

            return View(list);
        }
        public ActionResult ProjectAdd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ProjectAdd(Project project)
        {
            if (project.ProjectCode != null && projectRepository.GetCode(project.ProjectCode) == null)
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
        public ActionResult ProjectUpdate(int Id)
        {
            return View(projectRepository.TGet(Id));
        }
        [HttpPost]
        public ActionResult ProjectUpdate(Project project)
        {
            project.isEnabled = true;
            projectRepository.TUpdate(project);
            return RedirectToAction("ProjectList");
        }
        public ActionResult ProjectDelete(int Id)
        {
            Project project = projectRepository.TGet(Id);
            project.isEnabled = false;
            projectRepository.TUpdate(project);

            return RedirectToAction("ProjectList");

        }





        public ActionResult Products(string code)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.listProjectsOfCode = productRepository.List(code);
            mymodel.projectCode = code;
            mymodel.projectName = projectRepository.GetCode(code).ProjectName;
            mymodel.prev = 1;
            return View(mymodel);

            //return View(projectProductRepository.List(code));
        }


        /*
        public ActionResult ProductAdd( string code)
        {
            Project project = projectRepository.GetCode(code);
            return View( project);
        }
        [HttpPost]
        public ActionResult ProductAdd(Product p)
        {
            // check if the project code exists
            bool foundProject = false;
            bool existsAlready = false;
            if ( projectRepository.GetCode(p.ProjectCode) != null)
            {
                foundProject = true;
            }
            if (productRepository.GetSerialNumber( p.ProductSerialNumber) != null)
            {
                existsAlready = true;
            }

            if (foundProject && !existsAlready) // the project code is a valid project code
            {
                //projectRepository.GetCode(p.ProjectCode).ProjectProducts.Add(p);  to increase the couter...
                p.isEnabled = true;
                projectRepository.GetCode(p.ProjectCode).Connections++;
                productRepository.TAdd(p);
                return RedirectToAction("Products", new { code = p.ProjectCode });
            }
            else if (foundProject && existsAlready)
            {
                return View( projectRepository.GetCode( p.ProjectCode));
            }
            else // should not happen, but just in case
            {
                return RedirectToAction("ProjectList");
            }
        }*/
        /*
        public ActionResult ProductUpdate(string serialNumber) 
        {
            return View(projectProductRepository.GetSerialNumber(serialNumber));
        }
        [HttpPost]
        public ActionResult ProductUpdate(ProjectProduct p)
        {
            //ProjectProduct updating = projectProductRepository.GetSerialNumber(p.ProductSerialNumber);
            p.isEnabled = true;
            projectProductRepository.TUpdate(p);

            return RedirectToAction("Products", new { code = p.ProjectCode });

        }
        public ActionResult ProductDelete(string serialNumber)
        {
            ProjectProduct product = projectProductRepository.GetSerialNumber(serialNumber);
            product.isEnabled = false;
            projectProductRepository.TUpdate(product);

            return RedirectToAction("Products", new { code = product.ProjectCode });

        }*/
    }
}