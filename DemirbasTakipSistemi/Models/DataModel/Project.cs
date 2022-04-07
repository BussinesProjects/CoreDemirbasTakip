
//------------------------------------------------------------------------------
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemirbasTakipSistemi.Models.DataModel
{
    
    
    public partial class Project
    {
      
        public Project()
        {
            this.ProjectProducts = new HashSet<ProjectProduct>();
        }
        [Key]
        public string ProjectCode { get; set; }
        public string ProjectClient { get; set; }
        public string ProjectName { get; set; }
        public System.DateTime ProjectStartDate { get; set; }
        public string ProjectStatus { get; set; }
    
     
        public virtual ICollection<ProjectProduct> ProjectProducts { get; set; }
    }
}
