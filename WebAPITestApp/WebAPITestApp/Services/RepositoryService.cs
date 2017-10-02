using DBLayer.DbData;
using DBLayer.DBRepository;

namespace WebAPITestApp.Services
{
    public class RepositoryService
    {
        protected internal IDBRepository<Order> Repository { get; }

        public RepositoryService(IDBRepository<Order> _repository)
        {
            Repository = _repository;
        }

    }
}
