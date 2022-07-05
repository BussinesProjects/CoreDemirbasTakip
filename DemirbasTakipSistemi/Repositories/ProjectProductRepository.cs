using DemirbasTakipSistemi.Interface;
using DemirbasTakipSistemi.Models;
using DemirbasTakipSistemi.Models.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DemirbasTakipSistemi.Repositories
{
    public class ProjectProductRepository : Repository<ProjectProduct>
    {
        Context context = new Context();
        public List<ProjectProduct> List(string code)
        {

            return context.Set<ProjectProduct>().Where(x=>x.ProjectCode==code).ToList();
        }
        public ProjectProduct GetSerialNumber(string serialNumber)
        {

            return context.Set<ProjectProduct>().Where(x => x.ProductSerialNumber == serialNumber).FirstOrDefault();
        }

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

        }
    }
}