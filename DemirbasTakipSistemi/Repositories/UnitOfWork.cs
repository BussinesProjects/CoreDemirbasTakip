using DemirbasTakipSistemi.Interface;
using DemirbasTakipSistemi.Models;
using System.Threading.Tasks;

namespace DemirbasTakipSistemi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private CategoryRepository _categoryRepository;
        private PersonRepository _personRepository;
        private ProductRepository _productRepository;
        private ProjectRepository _projectRepository;
        private ProjectProductRepository _projectProductRepository;
        public UnitOfWork(Context context)
        {
            this._context = context;
        }

        public ICategoryRepository Categories => _categoryRepository= _categoryRepository ?? new CategoryRepository(_context);

        public IPersonRepository People => _personRepository = _personRepository ?? new PersonRepository(_context);

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public IProjectRepository Projects => _projectRepository = _projectRepository ?? new ProjectRepository(_context);

        public IProjectProductRepository ProjectProducts => _projectProductRepository = _projectProductRepository ?? new ProjectProductRepository(_context);

        public Task<int> CommitAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
