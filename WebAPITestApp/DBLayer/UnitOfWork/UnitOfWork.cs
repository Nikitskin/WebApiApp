using DBLayer.DbData;
using DBLayer.DBRepository;
using Microsoft.EntityFrameworkCore;
using System;

namespace DBLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(DbContext _db)
        {
            db = _db;
        }

        private DbContext db;
        private Lazy<IDbRepository<Order>> orders = new Lazy<IDbRepository<Order>>();
        private Lazy<IDbRepository<Product>> products = new Lazy<IDbRepository<Product>>();
        private Lazy<IDbRepository<User>> users = new Lazy<IDbRepository<User>>();
        private bool disposed = false;

        public void Save()
        {
            db.SaveChangesAsync();
        }

        public IDbRepository<Order> OrdersRepository => orders.Value;

        public IDbRepository<Product> ProductsRepository => products.Value; 

        public IDbRepository<User> UsersRepository => users.Value; 

        public void Dispose(bool disposing)
        {
            if (!disposed)
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