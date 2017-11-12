
using DBLayer.Contexts;
using DBLayer.DbData;
using Microsoft.EntityFrameworkCore;
using NLogger;

namespace DBLayer.DBRepository
{
    public class UserRepository : DbRepository<User>
    {
        public UserRepository(OrderContext context, ILoggerService logger) : base(context, logger)
        {

        }
    }
}