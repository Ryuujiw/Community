using Community.Models.Map;
using Microsoft.EntityFrameworkCore;

namespace Community.Data.Repositories
{
    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        public AreaRepository(MapContext mapContext) : base(mapContext)
        {
        }

        public async Task<IEnumerable<Area>> All()
        {
            try
            {
                return await _mapContext.Areas.Include(x => x.Trees).ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Area>();
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var existingArea = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (existingArea == null)
                {
                    return false;
                }
                _dbSet.Remove(existingArea);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Upsert(Area entity)
        {
            try
            {
                var existingArea = await _dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
                if (existingArea == null)
                {
                    return await Add(entity);
                }
                existingArea.Name = entity.Name;
                existingArea.Size = entity.Size;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
