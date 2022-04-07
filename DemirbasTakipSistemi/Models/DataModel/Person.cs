
using System.Collections.Generic;

namespace DemirbasTakipSistemi.Models.DataModel
{

    
    public partial class Person
    {
   
        public Person()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int PersonID { get; set; }
        public string PersonName { get; set; }
        public string PersonContact { get; set; }
    
    
        public virtual ICollection<Product> Products { get; set; }
    }
}
