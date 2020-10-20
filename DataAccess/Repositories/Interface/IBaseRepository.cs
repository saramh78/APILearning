using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interface
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        LearnApiContext Context { get; }

        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);

        TEntity Find(TKey id);

        Task<TEntity> FindAsync(TKey id);

        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);



        Task<List<TEntity>> GetAllAsync();

        void Delete(List<TEntity> entities);

        void Delete(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
