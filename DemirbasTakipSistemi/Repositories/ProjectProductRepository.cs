using DemirbasTakipSistemi.Interface;
using DemirbasTakipSistemi.Models;
using DemirbasTakipSistemi.Models.DataModel;

namespace DemirbasTakipSistemi.Repositories
{
    public class ProjectProductRepository : Repository<ProjectProduct>, IProjectProductRepository
    {
        public ProjectProductRepository(Context context)
          : base(context)
        {
        }
    }
}