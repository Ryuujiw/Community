using System.Linq.Expressions;

namespace Community.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task Remove(TEntity entity);
        Task RemoveRange(IEnumerable<TEntity> entities);
    }
}
