using System.Linq;
using WebAPITestApp.DBLayer.Contexts;
using WebAPITestApp.DBLayer.DbData;
using WebAPITestApp.NLogger;

namespace WebAPITestApp.DBLayer.DBRepository
{
    public class UserRepository : DbRepository<User>
    {
        public UserRepository(OrderContext context, ILoggerService logger) : base(context, logger)
        {

        }

        public override void Update(User item)
        {
            base.Update(item);
        }
    }
}