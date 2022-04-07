

using System.Collections.Generic;

namespace DemirbasTakipSistemi.Models.DataModel
{
    
    public partial class Role
    {
       
        public Role()
        {
            this.Logins = new HashSet<Login>();
        }
    
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    
      
        public virtual ICollection<Login> Logins { get; set; }
    }
}
