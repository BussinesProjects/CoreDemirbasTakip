using DemirbasTakipSistemi.Models.DataModel;
using DemirbasTakipSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace DemirbasTakipSistemi.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonRepository personRepository = new PersonRepository();
        // GET: Personal
        [HttpGet]
        public ActionResult PersonAdd()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult PersonAdd(Person person)
        {
            personRepository.TAdd(person);
            return View();
        }
        public ActionResult PersonList()
        {
            return View(personRepository.TList());
        }
        public ActionResult PersonUpdate(int id)
        {
           
            return View(personRepository.TGet(id));
        }
        [HttpPost]
        public ActionResult PersonUpdate(Person person)
       {
            personRepository.TUpdate(person);
            return View(person);
        }
        public ActionResult PersonDelete()
        {
            return View();
        }
    }
}