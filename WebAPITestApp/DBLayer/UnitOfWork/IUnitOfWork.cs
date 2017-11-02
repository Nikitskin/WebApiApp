using System.Threading.Tasks;
using DBLayer.DbData;
using DBLayer.DBRepository;

namespace DBLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDbRepository<Order> OrdersRepository { get; }
        IDbRepository<Product> ProductsRepository{ get; }
        IDbRepository<User> UsersRepository { get; }
        Task Save();
    }
}
