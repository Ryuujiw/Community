using Community.Data.Configuration;
using Community.Models.Map;

namespace Community.Services
{
    public class AreaService : IAreaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AreaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Area>> All()
        {
            return await _unitOfWork.Area.All();
        }
    }
}
