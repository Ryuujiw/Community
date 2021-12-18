using Community.Models.Map;

namespace Community.Services
{
    public interface IAreaService
    {
        Task<IEnumerable<Area>> All();
    }
}
