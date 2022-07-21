using DemirbasTakipSistemi.Interface;
using DemirbasTakipSistemi.Models;
using DemirbasTakipSistemi.Models.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DemirbasTakipSistemi.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        Context context = new Context();
        public List<Product> GetAll()
        {

            var data = context.Products
                      .Include(x => x.Category)
                      .Include(x => x.Person).AsNoTracking();

            return data.ToList();

        }
        public List<Product> List(string code)
        {

            return context.Set<Product>().Where(x => x.ProjectCode == code).ToList();
        }

        public Product GetSerialNumber(string serialNumber)
        {

            return context.Set<Product>().Where(x => x.ProductSerialNumber == serialNumber).FirstOrDefault();
        }
    }
}
