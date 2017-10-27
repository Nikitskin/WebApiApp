
using System.Threading.Tasks;
using DBLayer.DbData;
using Microsoft.EntityFrameworkCore;

namespace DBLayer.DBRepository
{
    public class OrderRepository : DbRepository<Order>
    {
        public OrderRepository(DbContext context) : base(context)
        {

        }
        public override async Task<Order> GetItem(int id)
        {
            return await DbSet.Include(order => order.OrderProduct).ThenInclude(product=>product.Product).FirstAsync(p => p.Id == id);
        }
    }
}