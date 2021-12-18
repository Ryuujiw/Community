using Community.Models.Map;
using Microsoft.EntityFrameworkCore;

namespace Community.Data.Repositories
{
    public class TreeRepository : GenericRepository<Tree>, ITreeRepository
    {
        public TreeRepository(MapContext mapContext) : base(mapContext)
        {
        }

        public override async Task<IEnumerable<Tree>> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Tree>();
            }
        }

        public override async Task<bool> Upsert(Tree entity)
        {
            try
            {
                var existingTree = await _dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
                if (existingTree == null)
                {
                    return await Add(entity);
                }
                existingTree.Name = entity.Name;
                existingTree.Area = entity.Area;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var existingTree = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (existingTree == null)
                {
                    return false;
                }
                _dbSet.Remove(existingTree);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
