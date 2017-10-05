using DBLayer.DbData;
using DBLayer.DBRepository;

namespace DBLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDBRepository<Order> OrdersRepository { get; }
        IDBRepository<Product> ProductsRepository{ get; }
        IDBRepository<User> UsersRepository { get; }
        void Save();
    }
}
