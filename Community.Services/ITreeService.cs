using Community.Models.Map;

namespace Community.Services
{
    public interface ITreeService
    {
        Task<IEnumerable<Tree>> All();
    }
}
