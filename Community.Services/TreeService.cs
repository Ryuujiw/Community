using Community.Data.Configuration;
using Community.Models.Map;

namespace Community.Services
{
    public class TreeService : ITreeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TreeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Tree>> All()
        {
            return await _unitOfWork.Tree.All();
        }
    }
}
