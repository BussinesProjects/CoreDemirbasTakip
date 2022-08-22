using DemirbasTakipSistemi.Interface;
using DemirbasTakipSistemi.Models;
using DemirbasTakipSistemi.Models.DataModel;
using System.Linq;

namespace DemirbasTakipSistemi.Repositories
{
    public class ProjectRepository : Repository<Project>
    {
        Context context = new Context();
        public Project GetCode(string code)
        {
             //return context.Set<Project>().Find(code);
             return context.Set<Project>().Where(x => x.ProjectCode == code).FirstOrDefault();
        }
        public Project GetProjectId( int id)
        {
            return context.Set<Project>().Where(x => x.Id == id).FirstOrDefault();
        }

    }
}