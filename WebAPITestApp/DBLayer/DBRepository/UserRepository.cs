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
            var user = Context.Users.First(u => u.UserName == item.UserName);
            user.Password = item.Password;
            base.Update(user);
        }
    }
}