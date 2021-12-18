using Community.Data.Repositories;

namespace Community.Data.Configuration
{
    public interface IUnitOfWork
    {
        ITreeRepository Tree { get; }
        Task CompleteAsync();
        void Dispose();

    }
}
