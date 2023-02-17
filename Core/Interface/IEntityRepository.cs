using Core.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Interface.IRepository
{
    public interface IEntityRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> All { get; }
        void Delete(TEntity entity); 
        void Dispose();
        void Dispose(bool disposing);
        int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        TEntity Get(object id);
        Task<TEntity> GetAsync(object id);
        Task InserOrUpdateAsync(TEntity entity);
        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);
        IQueryable<TEntity> SqlQuery(string sql, params object[] parameters);
        void Update(TEntity entity);
    }
}
