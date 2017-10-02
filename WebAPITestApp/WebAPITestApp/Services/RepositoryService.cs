using DBLayer.DBRepository;

namespace WebAPITestApp.Services
{
    public class RepositoryService<T> where T : class
    {
        protected internal IDBRepository<T> Repository { get; }

        public RepositoryService(IDBRepository<T> _repository)
        {
            Repository = _repository;
        }

    }
}
