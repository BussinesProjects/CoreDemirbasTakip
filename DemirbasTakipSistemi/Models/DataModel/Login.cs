

using System.Collections.Generic;

namespace DemirbasTakipSistemi.Models.DataModel
{
    
    public partial class Login
    {
       
        public Login()
        {
            this.PatchNotes = new HashSet<PatchNote>();
        }
    
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
   
        public virtual ICollection<PatchNote> PatchNotes { get; set; }
    }
}
