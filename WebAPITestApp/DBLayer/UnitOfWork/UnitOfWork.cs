using DBLayer.Contexts;
using DBLayer.DbData;
using DBLayer.DBRepository;
using System;

namespace DBLayer.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        OrderContext db = new OrderContext();
        IDBRepository<Order> orders;
        IDBRepository<Product> products;
        IDBRepository<User> users;

        private bool disposed = false;

        public void Save()
        {
            db.SaveChanges();
        }

        public IDBRepository<Order> Orders
        {
            get
            {
                if (orders == null)
                {
                    orders = new DBRepository<Order>(db);
                }
                return orders;
            }
        }
        public IDBRepository<Product> Products
        {
            get
            {
                if (products == null)
                {
                    products = new DBRepository<Product>(db);
                }
                return products;
            }
        }
        public IDBRepository<User> Users
        {
            get
            {
                if (users == null)
                {
                    users = new DBRepository<User>(db);
                }
                return users;
            }
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}