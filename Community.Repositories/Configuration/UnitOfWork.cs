using Community.Data.Repositories;

namespace Community.Data.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MapContext _mapContext;

        public ITreeRepository Tree { get; private set; }

        public IAreaRepository Area { get; private set; }

        public UnitOfWork(MapContext mapContext)
        {
            _mapContext = mapContext;
            Tree = new TreeRepository(mapContext);
            Area = new AreaRepository(mapContext);
        }

        public async Task CompleteAsync()
        {
            await _mapContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _mapContext.Dispose();
        }
    }
}
