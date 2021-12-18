using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Community.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected MapContext _mapContext;
        internal DbSet<T> _dbSet;

        public GenericRepository(MapContext mapContext)
        {
            _mapContext = mapContext;
            _dbSet = _mapContext.Set<T>();
        }
        public virtual Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}
