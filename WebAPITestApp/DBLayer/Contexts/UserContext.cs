using DBLayer.DbData;
using System.Data.Entity;

namespace DBLayer.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext() : base("DBConnection")
        {  
        }

        public DbSet<User> Orders { get; set; }

    }
}
