﻿using System.Collections.Generic;
using System.Data.Entity;

namespace DBLayer.DBRepository
{
    public class DBRepository<T> : IDBRepository<T>
        where T : class, new()
    {
        private DbContext context;
        private DbSet<T> dbSet;

        public DBRepository(DbContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }

        public void Create(T item)
        {
            dbSet.Add(item);
        }

        public void Delete(T item)
        {
            dbSet.Remove(item);
        }

        public T GetItem(int id)
        {
            return dbSet.FindAsync(id).Result;
        }

        public IEnumerable<T> GetAll()
        {
            var list = new List<T>();
            dbSet.ForEachAsync(item => list.Add(item));
            return list;
        }

        public void Update(T item, T newItem)
        {
            dbSet.Remove(item);
            dbSet.Add(newItem);
        }
    }
}