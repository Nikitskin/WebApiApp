﻿using DBLayer.DbData;
using DBLayer.DBRepository;
using System;
using System.Data.Entity;

namespace DBLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
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

        public IDBRepository<Order> Orders
        {
            get
            {
                return orders;
            }
        }

        public IDBRepository<Product> Products
        {
            get
            {
                return products;
            }
        }

        public IDBRepository<User> Users
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