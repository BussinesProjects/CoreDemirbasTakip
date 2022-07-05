using DemirbasTakipSistemi.Interface;
using DemirbasTakipSistemi.Models;
using DemirbasTakipSistemi.Models.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DemirbasTakipSistemi.Repositories
{
    public class ProjectProductRepository : Repository<Product>
    {
        Context context = new Context();
        public List<Product> List(string code)
        {

            return context.Set<Product>().Where(x=>x.ProjectCode==code).ToList();
        }
        public Product GetSerialNumber(string serialNumber)
        {

            return context.Set<Product>().Where(x => x.ProductSerialNumber == serialNumber).FirstOrDefault();
        }
        /*
        public List<ProjectProduct> GetAll()
        {

            var data = context.ProjectProducts
                      .Include(x => x.Project).AsNoTracking();

            return data.ToList();

        }
        public void TAdd(ProjectProduct paramater)
        {
            context.ProjectProducts.Add(paramater);
            context.SaveChanges();

        }

        public void TUpdate(ProjectProduct paramater)
        {
            context.ProjectProducts.Update(paramater);
            context.SaveChanges();

        }*/
    }
}