using SimpleApi1.Models;
using System.Collections.Generic;
using System.Linq;
using SimpleApi1.Repositories.Interface;

namespace SimpleApi1.Repositories.Class
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        protected static List<TEntity> _entities = new List<TEntity>();

        public void Delete(TKey id)
        {
            _entities.RemoveAll(x => x.Id.Equals(id));
        }

        public virtual TEntity Add(TEntity entity)
        {
            _entities.Add(entity);
            return entity;
        }

        public List<TEntity> GetAll()
        {
            return _entities;
        }

        public TEntity Find(TKey id)
        {
           return _entities.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }
    }


}

