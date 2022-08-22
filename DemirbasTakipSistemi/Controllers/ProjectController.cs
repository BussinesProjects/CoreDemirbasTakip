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
            var list = productRepository.ListById( project.Id); // finds all the products

            foreach (Product prod in list)
            {
                prod.ProjectCode = project.ProjectCode;
                prod.ProjectName = project.ProjectName;
                prod.isEnabled = true;
                productRepository.TUpdate(prod);
            }

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





        public ActionResult Products(string code, int id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.listProjectsOfCode = productRepository.List(code);
            mymodel.projectCode = code;
            if (projectRepository.GetProjectId(id).ProjectName!= null)
            {
                mymodel.projectName = projectRepository.GetProjectId(id).ProjectName;
            }
            mymodel.prev = 1;
            return View(mymodel);

            //return View(projectProductRepository.List(code));
        }

    }
}