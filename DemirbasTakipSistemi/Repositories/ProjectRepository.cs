using DemirbasTakipSistemi.Interface;
using DemirbasTakipSistemi.Models;
using DemirbasTakipSistemi.Models.DataModel;

namespace DemirbasTakipSistemi.Repositories
{
    public class ProjectRepository : Repository<Project>
    {
        Context context = new Context();
        public Project GetCode(string code)
        {
             return context.Set<Project>().Find(code);
        }

    }
}