using System;
using System.Threading.Tasks;

namespace DemirbasTakipSistemi.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IPersonRepository People { get; }
        IProductRepository Products { get; }
        IProjectRepository Projects { get; }
        IProjectProductRepository ProjectProducts { get; }
     
        Task<int> CommitAsync();
    }
}
