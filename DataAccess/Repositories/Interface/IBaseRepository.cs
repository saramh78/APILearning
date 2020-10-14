using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interface
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);

        TEntity Find(TKey id);

        Task<TEntity> FindAsync(TKey id);

        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();

        void Delete(List<TEntity> entities);

        void Delete(TEntity entity);
    }
}
