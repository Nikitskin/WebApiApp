
using System.Threading.Tasks;
using DBLayer.DbData;
using Microsoft.EntityFrameworkCore;
using NLogger;

namespace DBLayer.DBRepository
{
    public class OrderRepository : DbRepository<Order>
    {
        public OrderRepository(DbContext context, ILoggerService logger) : base(context, logger)
        {

        }
        public override async Task<Order> GetItem(int id)
        {
            return await DbSet.Include(order => order.OrderProduct).
                ThenInclude(product=>product.Product).FirstAsync(p => p.Id == id);
        }
    }
}