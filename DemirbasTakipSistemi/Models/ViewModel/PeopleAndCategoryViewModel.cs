using DemirbasTakipSistemi.Models.DataModel;
using System.Collections.Generic;

namespace DemirbasTakipSistemi.Models.ViewModel
{
    public class PeopleAndCategoryViewModel
    {
        public List<Person> People { get; set; }
        public List<Category> Categories { get; set; }
        public List<Project> Projects { get; set; }
        public string Proj { get; set; }
        public int Prev { get; set; }
    }
}
