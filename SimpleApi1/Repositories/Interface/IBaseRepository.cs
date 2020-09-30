using System.Collections.Generic;

namespace SimpleApi1.Repositories.Interface
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class 
    {
        TEntity Add(TEntity entity);

        TEntity Find(TKey id);

        List<TEntity> GetAll();

        void Delete(TKey id);

        void Delete(TEntity entity);
    }
}
