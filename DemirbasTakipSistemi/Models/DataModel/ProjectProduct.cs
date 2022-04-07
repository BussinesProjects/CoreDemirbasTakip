
using System.ComponentModel.DataAnnotations;

namespace DemirbasTakipSistemi.Models.DataModel
{
    
    
    public partial class ProjectProduct
    {
        [Key]
        public string ProjectCode { get; set; }
        public string ProductSerialNumber { get; set; }
        public string ProductBrand { get; set; }
        public string ProductModel { get; set; }
        public System.DateTime RegisterDateTime { get; set; }
        public int ProductAmount { get; set; }
        public System.DateTime ProductWarrantyStartDate { get; set; }
        public string ProductServiceContact { get; set; }
        public string ProductFeatures { get; set; }
        public string ProductImage { get; set; }
        public System.DateTime ProductWarrantyFinishDate { get; set; }
        public string ProductProvider { get; set; }
    
        public virtual Project Project { get; set; }
    }
}
