using challenge.emision.domain.Contracts;

namespace challenge.emision.domain.Interfaces.RepositoryPattern
{
    public interface IUnitOfWork<TId> : IDisposable
    {
        IRepository<TEntity, TId> Repository<TEntity>() where TEntity : AuditableEntity<TId>;
        Task<int> SaveChanges();        
    }
}
