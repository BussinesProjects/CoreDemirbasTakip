
//------------------------------------------------------------------------------
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemirbasTakipSistemi.Models.DataModel
{
    
    
    public partial class Project
    {
        
        //public Project()
        //{
        //    this.ProjectProducts = new HashSet<Product>();
        //}
        [Key]
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public int Connections { get; set; }
        public string ProjectName { get; set; }
        public bool isEnabled { get; set; }
        public string ProjectClient { get; set; }
        public System.DateTime ProjectStartDate { get; set; }
        public string ProjectStatus { get; set; }
    
     
        public virtual ICollection<Product> ProjectProducts { get; set; }
    }
}
