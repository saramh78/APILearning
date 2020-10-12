using DataAccess.Model;
using DataAccess.Models;
using DataAccess.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected readonly LearnApiContext _context;

        //  protected static List<TEntity> _entities = new List<TEntity>();
        public BaseRepository(LearnApiContext learnApiContext)
        {
            _context = learnApiContext;
        }

        public void Delete(List<TEntity> entities)
        {
            // _context.RemoveAll(x => x.Id.Equals(id));
            _context.Set<TEntity>().RemoveRange(entities);
            _context.SaveChanges();
        }


        public virtual TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity Find(TKey id)
        {
            //cannot use
            //   return _entities.FirstOrDefault(x => x.Id == id));

            return _context.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
