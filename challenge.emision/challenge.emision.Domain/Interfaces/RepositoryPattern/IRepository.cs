using challenge.emision.domain.Contracts;
using System.Linq.Expressions;

namespace challenge.emision.domain.Interfaces.RepositoryPattern
{
    public interface IRepository<TEntity, TId> where TEntity : AuditableEntity<TId>
    {
        #region IRepository<T> Members

        /// Retorna un objeto del tipo AsQueryable
        IQueryable<TEntity> AsQueryable();

        /// Retorna un objeto del tipo AsQueryable y acepta como parámetro las relaciones a incluir
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

        Task<List<TEntity>> GetAllAsync();

        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        /// Función que retorna una entidad, a partir de una consulta.
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        /// Función que retorna una entidad, a partir de una consulta sin atachar.
        IEnumerable<TEntity> FindAllNoTracking(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        /// Retorna la ultima entidad encontrada bajo una condición especificada
        TEntity First(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        /// Retorna la primera entidad encontrada bajo una condición especificada
        TEntity Last(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        /// Retorna la primera entidad encontrada bajo una condición especificada o null sino encontrara registros
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        ///  Retorna la primera entidad encontrada bajo una condición especificada o null sino encontrara registros
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        TEntity FirstOrDefaultNoTracking(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        /// Retorna la ultima entidad encontrada bajo una condición especificada o null sino encontrara registros
        TEntity LastOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        /// Retorna una entidad bajo una condición especificada
        TEntity Single(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        /// Retorna una entidad bajo una condición especificada o null sino encontrara registros
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity Get<TDataType>(TDataType id, Expression<Func<TEntity, object>> includes, Expression<Func<TEntity, bool>> predicate) where TDataType : struct;

        Task<TEntity> GetByIdAsync(TId id);

        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate = null);

        bool Exist(Expression<Func<TEntity, bool>> predicate = null);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity Get<TDataType>(TDataType id) where TDataType : struct;

        Task<List<TEntity>> GetPagedResponseAsync(int pageNumber, int pageSize);

        /// Registra una entidad
        void Insert(TEntity entity);

        /// Registra varias entidades
        void Insert(IEnumerable<TEntity> entities);

        /// Actualiza una entidad
        void Update(TEntity entity);

        /// Actualiza varias entidades
        void Update(IEnumerable<TEntity> entities);

        /// Elimina una entidad
        void Delete(TEntity entity);

        /// Elimina por Id
        void Delete(object id);

        /// Elimina un conjuto de entidades
        void Delete(IEnumerable<TEntity> entities);

        #endregion IRepository<T> Members       
    }
}
