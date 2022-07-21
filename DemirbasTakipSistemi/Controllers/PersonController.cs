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
            person.isEnabled = true;
            personRepository.TAdd(person);
            return RedirectToAction("PersonList");
        }
        public ActionResult PersonList()
        {
            return View(personRepository.TList());
        }
        public ActionResult PersonUpdate(int id)
        {
           
            return View(personRepository.TGet(id));
        }
        public ActionResult PersonInfo(int id)
        {
            return View(personRepository.TGet(id));
        }
        [HttpPost]
        public ActionResult PersonUpdate(Person person)
       {
            person.isEnabled = true;
            personRepository.TUpdate(person);
            return RedirectToAction("PersonList");
        }
        public ActionResult PersonDelete(int id)
        {
            //personRepository.TDelete( personRepository.TGet(id));
            Person person = personRepository.TGet(id);
            person.isEnabled = false;
            personRepository.TUpdate(person);

            return RedirectToAction("PersonList");
        }
    }
}