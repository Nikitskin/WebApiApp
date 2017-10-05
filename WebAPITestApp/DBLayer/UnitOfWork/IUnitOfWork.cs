
using DBLayer.DbData;
using DBLayer.DBRepository;

namespace DBLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        // TODO Add properties for repositories to this interface
        IDBRepository<Order> Orders { get; }
        void Save();
    }
}
