using DBLayer.DbData;
using DBLayer.DBRepository;
using Microsoft.EntityFrameworkCore;
using System;

namespace DBLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(DbContext db)
        {
            _db = db;
        }

        private readonly DbContext _db;
        private Lazy<IDbRepository<Order>> orders;
        private Lazy<IDbRepository<Product>> products;
        private Lazy<IDbRepository<User>> users;
        private bool _disposed;

        public void Save()
        {
            _db.SaveChangesAsync();
        }

        public IDbRepository<Order> OrdersRepository
        {
            get
            {
                if (orders == null)
                {
                    orders = new Lazy<IDbRepository<Order>>(() => new DbRepository<Order>(_db));
                }
                return orders.Value;
            }
        }

        public IDbRepository<Product> ProductsRepository
        {
            get
            {
                if (products == null)
                {
                    products = new Lazy<IDbRepository<Product>>(() => new DbRepository<Product>(_db));
                }
                return products.Value;
            }
        }

        public IDbRepository<User> UsersRepository
        {
            get
            {
                if (users == null)
                {
                    users = new Lazy<IDbRepository<User>>(() => new DbRepository<User>(_db));
                }
                return users.Value;
            }
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }
       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}