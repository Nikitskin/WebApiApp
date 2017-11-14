using System.Threading.Tasks;
using DBLayer.Contexts;
using DBLayer.DbData;
using Microsoft.EntityFrameworkCore;
using NLogger;

namespace DBLayer.DBRepository
{
    public class ProductRepository : DbRepository<Product>
    {
        public ProductRepository(OrderContext context, ILoggerService logger) : base(context, logger)
        {

        }
        public override async Task<Product> GetItem(int id)
        {
            return await DbSet.Include(product => product.OrderProduct).
                ThenInclude(order => order.Order).
                FirstAsync(p => p.Id == id);
        }
    }
}