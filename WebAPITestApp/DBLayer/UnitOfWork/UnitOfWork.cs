using DBLayer.DbData;
using DBLayer.DBRepository;
using Microsoft.EntityFrameworkCore;
using System;

namespace DBLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        // TODO read about System.Lazy class. Now all your repositories instatiate every time you create an UnitOfWork object
        // TODO but if you use smth like _usersRepository = new Lazy<IUserRepository>(() => new UserRepository(context));
        // Repository will be created only when you call unitOfWork.UserRepository
        public UnitOfWork(IDbRepository<Order> _orders, IDbRepository<Product> _products, IDbRepository<User> _users, DbContext _db)
        {
            orders = _orders;
            products = _products;
            users = _users;
            db = _db;
        }

        private DbContext db;
        private IDbRepository<Order> orders;
        private IDbRepository<Product> products;
        private IDbRepository<User> users;
        private bool disposed = false;

        public void Save()
        {
            db.SaveChangesAsync();
        }

        public IDbRepository<Order> OrdersRepository
        {
            get
            {
                return orders;
            }
        }

        public IDbRepository<Product> ProductsRepository
        {
            get
            {
                return products;
            }
        }

        public IDbRepository<User> UsersRepository 
        {
            get
            {
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