using DataAccess.Model;
using DataAccess.Models;
using DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public virtual void Delete(List<TEntity> entities)
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


        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity Find(TKey id)
        {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(id));
        }

        public virtual async Task<TEntity> FindAsync(TKey id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));

        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();

        }

    }
}
