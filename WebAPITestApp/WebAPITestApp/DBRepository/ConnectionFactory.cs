
using System.Data.Entity;
using WebAPITestApp.Contexts;

namespace WebAPITestApp.DBRepository
{
    public static class ConnectionFactory
    {
        public static DbContext GetContext()
        {
            // implement repository pattern
            using (OrderContext db = new OrderContext())
            {
                
            }
            return null;
        }
    }
}
