
using System.Threading.Tasks;
using DBLayer.DbData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace DBLayer.DBRepository
{
    public class OrderRepository : DbRepository<Order>
    {
        public OrderRepository(DbContext context) : base(context)
        {

        }
        public override async Task<Order> GetItem(int id)
        {
            return await DbSet.Include(order => order.OrderProduct).FirstAsync(p => p.Id == id);
        }
    }
}