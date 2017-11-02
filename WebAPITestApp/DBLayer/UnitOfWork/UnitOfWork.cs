using DBLayer.DbData;
using DBLayer.DBRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using NLogger;

namespace DBLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ILoggerService _logger;

        public UnitOfWork(DbContext db, ILoggerService logger)
        {
            _db = db;
            _logger = logger;
        }

        private readonly DbContext _db;
        private Lazy<IDbRepository<Order>> _orders;
        private Lazy<IDbRepository<Product>> _products;
        private Lazy<IDbRepository<User>> _users;
        private bool _disposed;

        public async Task Save()
        {
            _logger.Trace("Saving changes to db..");
            await _db.SaveChangesAsync();
            _logger.Trace("Saving finished for db.");
        }

        public IDbRepository<Order> OrdersRepository
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new Lazy<IDbRepository<Order>>(() => new OrderRepository(_db, _logger));
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
                    _products = new Lazy<IDbRepository<Product>>(() => new ProductRepository(_db, _logger));
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
                    _users = new Lazy<IDbRepository<User>>(() => new UserRepository(_db, _logger));
                }
                return _users.Value;
            }
        }

        public void Dispose(bool disposing)
        {
            //    if (!_disposed)
            //    {
            //        if (disposing)
            //        {
            _db.Dispose();
            //    }
            //    _disposed = true;
            //}
        }
       
        public void Dispose()
        {
            _logger.Trace("Disposing unit of work");
            Dispose(true);
            GC.SuppressFinalize(this);
            _logger.Trace("Disposin finished for unit of work");
        }
    }
}