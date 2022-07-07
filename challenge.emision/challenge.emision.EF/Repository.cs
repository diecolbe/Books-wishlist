using challenge.emision.domain.Contracts;
using challenge.emision.domain.Interfaces.RepositoryPattern;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace challenge.emision.EF
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : AuditableEntity<TId>
    {
        private readonly DbContext _dbcontext;
        private readonly DbSet<TEntity> _entities;

        public Repository(DbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _entities = dbcontext.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet
        {
            get
            {
                return _dbcontext.Set<TEntity>();
            }
        }

        private IQueryable<TEntity> PerformInclusions(IEnumerable<Expression<Func<TEntity, object>>> includeProperties,
                                                IQueryable<TEntity> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        #region IRepository<TEntity> Members

        public IQueryable<TEntity> AsQueryable()
        {
            return _entities.AsQueryable<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            return PerformInclusions(includeProperties, query);
        }

        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            var set = _dbcontext.Set<TEntity>();
            return (predicate == null) ? await set.AnyAsync() : await set.AnyAsync(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync<TEntity>(predicate);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = AsQueryable();
            return query.FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        public IEnumerable<TEntity> FindAllNoTracking(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable().AsNoTracking();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        public TEntity First(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.First(where);
        }

        public TEntity Last(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Last(where);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.FirstOrDefault(where);
        }

        public TEntity FirstOrDefaultNoTracking(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable().AsNoTracking();
            query = PerformInclusions(includeProperties, query);
            return query.FirstOrDefault(where);
        }

        public TEntity LastOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.LastOrDefault(where);
        }

        public TEntity LastOrDefaultNoTracking(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable().AsNoTracking();
            query = PerformInclusions(includeProperties, query);
            return query.LastOrDefault(where);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Single(where);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.SingleOrDefault(where);
        }

        public TEntity Get<TDataType>(TDataType id) where TDataType : struct
        {
            return _dbcontext.Set<TEntity>().Find(id);
        }

        public TEntity Get<TDataType>(TDataType id,
            Expression<Func<TEntity, object>> includes,
            Expression<Func<TEntity, bool>> predicate) where TDataType : struct
        {
            return _dbcontext.Set<TEntity>().Include(includes).SingleOrDefault(predicate);
        }

        public void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            _entities.Attach(entity);
            _dbcontext.Entry(entity).State = EntityState.Modified;
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dbcontext.Entry(e).State = EntityState.Modified;
            }
        }

        public void Delete(TEntity entity)
        {
            if (_dbcontext.Entry(entity).State == EntityState.Detached)
            {
                _entities.Attach(entity);
            }
            _entities.Remove(entity);
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = _entities.Find(id);
            _entities.Remove(entityToDelete);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dbcontext.Entry(e).State = EntityState.Deleted;
            }
        }

        public async Task<List<TEntity>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            return await _dbcontext
                .Set<TEntity>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await _dbcontext.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbcontext
                .Set<TEntity>()
                .ToListAsync();
        }

        public bool Exist(Expression<Func<TEntity, bool>> predicate = null)
        {
            var set = _dbcontext.Set<TEntity>();
            return (predicate == null) ? set.Any() : set.Any(predicate);
        }

        #endregion IRepository<TEntity> Members
    }
}
