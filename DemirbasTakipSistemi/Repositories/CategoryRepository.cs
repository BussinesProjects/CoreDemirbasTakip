using DemirbasTakipSistemi.Interface;
using DemirbasTakipSistemi.Models;
using DemirbasTakipSistemi.Models.DataModel;

namespace DemirbasTakipSistemi.Repositories
{
    public  class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context context)
          : base(context)
        {
        }
    }
}