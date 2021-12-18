using Community.Data.Repositories;

namespace Community.Data.Configuration
{
    public interface IUnitOfWork
    {
        ITreeRepository Tree { get; }
        IAreaRepository Area { get; }
        Task CompleteAsync();
        void Dispose();

    }
}
