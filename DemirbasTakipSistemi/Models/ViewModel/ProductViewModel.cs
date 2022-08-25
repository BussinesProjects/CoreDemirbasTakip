using DemirbasTakipSistemi.Models.DataModel;
using Microsoft.AspNetCore.Http;

namespace DemirbasTakipSistemi.Models.ViewModel
{
    public class ProductViewModel
    {
        public Product product { get; set; }
        public IFormFile ProductImage { get; set; }
    }
}
