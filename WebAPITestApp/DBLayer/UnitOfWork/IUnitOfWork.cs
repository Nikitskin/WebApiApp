using System.Threading.Tasks;
using WebAPITestApp.DBLayer.DbData;
using WebAPITestApp.DBLayer.DBRepository;

namespace WebAPITestApp.DBLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDbRepository<Order> OrdersRepository { get; }
        IDbRepository<Product> ProductsRepository{ get; }
        IDbRepository<User> UsersRepository { get; }
        Task Save();
    }
}
