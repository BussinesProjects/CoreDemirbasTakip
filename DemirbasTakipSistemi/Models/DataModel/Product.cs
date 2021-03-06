//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace DemirbasTakipSistemi.Models.DataModel
{
    
    
    public partial class Product
    {
        [Key]
        public int Id { get; set; }
        // the ones marked with // are implemented, the others are not.
        // the ones marked with ** are displayed in the table
        public bool isEnabled { get; set; }//
        public int CategoryID { get; set; }// **
        public int PersonID { get; set; }// **
        public int ProductAmount { get; set; }// **
        public string ProductSerialNumber { get; set; }// **
        public string ProjectCode { get; set; }// **
        public string ProductModel { get; set; }//
        public string ServiceContact { get; set; }//
        public string ProductBrand { get; set; }// 
        public string ProductFeatures { get; set; }//
        public string ProductProvider { get; set; }//
        public string ProductImage { get; set; }
        public string ProductServiceContact { get; set; }//
        public System.DateTime RegisterDateTime { get; set; } // **
        public System.DateTime ProductWarrantyDate { get; set; }
        public System.DateTime ProductWarrantyStartDate { get; set; }//
        public System.DateTime ProductWarrantyFinishDate { get; set; }//

        public virtual Category Category { get; set; }// // not used
        public virtual Person Person { get; set; }// // not used
        public virtual Project Project { get; set; } // not used

    }
}
