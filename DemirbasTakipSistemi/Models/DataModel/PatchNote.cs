
using System;

namespace DemirbasTakipSistemi.Models.DataModel
{
   
    
    public partial class PatchNote
    {
        public int PatchID { get; set; }
        public string PatchVersion { get; set; }
        public string PatchType { get; set; }
        public string PatchNote1 { get; set; }
        public Nullable<System.DateTime> PatchDateTime { get; set; }
        public Nullable<int> Id { get; set; }
    
        public virtual Login Login { get; set; }
    }
}
