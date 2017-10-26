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
        private Lazy<IDbRepository<Order>> _orders;
        private Lazy<IDbRepository<Product>> _products;
        private Lazy<IDbRepository<User>> _users;
        private bool _disposed;

        public void Save()
        {
            _db.SaveChangesAsync();
        }

        public IDbRepository<Order> OrdersRepository
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new Lazy<IDbRepository<Order>>(() => new OrderRepository(_db));
                }
                return _orders.Value;
            }
        }

        public IDbRepository<Product> ProductsRepository
        {
            get
            {
                if (_products == null)
                {
                    _products = new Lazy<IDbRepository<Product>>(() => new ProductRepository(_db));
                }
                return _products.Value;
            }
        }

        public IDbRepository<User> UsersRepository
        {
            get
            {
                if (_users == null)
                {
                    _users = new Lazy<IDbRepository<User>>(() => new DbRepository<User>(_db));
                }
                return _users.Value;
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