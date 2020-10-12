using System.Collections.Generic;

namespace DataAccess.Repositories.Interface
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        TEntity Add(TEntity entity);

        TEntity Find(TKey id);

        List<TEntity> GetAll();

        void Delete(List<TEntity> entities);

        void Delete(TEntity entity);
    }
}
