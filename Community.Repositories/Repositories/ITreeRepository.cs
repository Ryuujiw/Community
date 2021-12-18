using Community.Models.Map;

namespace Community.Data.Repositories
{
    public interface ITreeRepository : IRepository<Tree>
    {
        Task<IEnumerable<Tree>> GetAll();
        Task<Tree> GetById(Guid id);
        Task<Tree> GetByName(string name);
    }
}
