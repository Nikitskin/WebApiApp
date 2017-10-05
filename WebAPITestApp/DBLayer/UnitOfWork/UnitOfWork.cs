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
        public UnitOfWork(IDBRepository<Order> _orders, IDBRepository<Product> _products, IDBRepository<User> _users, DbContext _db)
        {
            orders = _orders;
            products = _products;
            users = _users;
            db = _db;
        }

        private DbContext db;
        private IDBRepository<Order> orders;
        private IDBRepository<Product> products;
        private IDBRepository<User> users;
        private bool disposed = false;

        public void Save()
        {
            db.SaveChangesAsync();
        }

        public IDBRepository<Order> OrdersRepository
        {
            get
            {
                return orders;
            }
        }

        public IDBRepository<Product> ProductsRepository
        {
            get
            {
                return products;
            }
        }

        public IDBRepository<User> UsersRepository 
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