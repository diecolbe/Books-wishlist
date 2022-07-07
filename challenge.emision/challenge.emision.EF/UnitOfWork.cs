using challenge.emision.domain.Contracts;
using challenge.emision.domain.Interfaces.RepositoryPattern;
using challenge.emision.EF.Context;
using System.Collections;

namespace challenge.emision.EF
{
    public class UnitOfWork<TId> : IUnitOfWork<TId>
    {
        private readonly BookswishlistDbContext _dbContext;
        private Hashtable _repositories;
        private bool disposed;

        public UnitOfWork(BookswishlistDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IRepository<TEntity, TId> Repository<TEntity>() where TEntity : AuditableEntity<TId>
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<,>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TId)), _dbContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity, TId>)_repositories[type];
        }

        public Task<int> SaveChanges()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _dbContext.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }
    }
}
