using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using NLogger;

namespace DBLayer.DBRepository
{
    public class DbRepository<T> : IDbRepository<T>
        where T : class, new()
    {
        protected DbContext Context;
        protected DbSet<T> DbSet;
        private readonly ILoggerService _logger;

        public DbRepository(DbContext context, ILoggerService logger)
        {
            Context = context;
            DbSet = Context.Set<T>();
            _logger = logger;
        }

        public virtual void Create(T item)
        {
            try
            {
                DbSet.Add(item);
            }
            catch (Exception e)
            {
                _logger.Error("Was unable to add item {0} because of error {1}", item, e);
            }
        }

        public virtual void Delete(T item)
        {
            try
            {
                DbSet.Remove(item);
            }
            catch (Exception e)
            {
                _logger.Error("Was unable to remove item {0} because of error {1}", item, e);
            }
        }

        public virtual async Task<T> GetItem(int id)
        {
            try
            {
                return await DbSet.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.Error("Was unable to get item with {0} because of error {1}", id, e);
            }
            return null;
        }

        public virtual async Task<List<T>> GetAll()
        {
            try
            {
                return await DbSet.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.Error("Was unable to get all items because of error {0}", e);
            }
            return null;
        }

        public virtual void Update(T item)
        {
            try
            {
                DbSet.Update(item);
            }
            catch (Exception e)
            {
                _logger.Error("Was unable to update item {0} cause error {1}", item, e);
            }
        }
    }
}
