using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.Contexts;
using NLogger;

namespace DBLayer.DBRepository
{
    public class DbRepository<T> : IDbRepository<T>
        where T : class, new()
    {
        protected OrderContext Context;
        protected DbSet<T> DbSet;
        private readonly ILoggerService _logger;

        public DbRepository(OrderContext context, ILoggerService logger)
        {
            Context = context;
            DbSet = Context.Set<T>();
            _logger = logger;
        }

        public virtual async void Create(T item)
        {
            try
            {
                await DbSet.AddAsync(item);
            }
            catch (Exception e)
            {
                _logger.Error("Was unable to add item {0} because of error {1}", item, e);
                throw;
            }
        }

        public virtual void Delete(T item)
        {
            try
            {
                //TODO no async?
                DbSet.Remove(item);
            }
            catch (Exception e)
            {
                _logger.Error("Was unable to remove item {0} because of error {1}", item, e);
                throw;
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
                throw;
            }
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
                throw;
            }
        }

        public virtual void Update(T item)
        {
            try
            {
                //TODO No async?
                //DbSet.Update(item);
                DbSet.Attach(item);
                Context.Entry(item).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                _logger.Error("Was unable to update item {0} cause error {1}", item, e);
                throw;
            }
        }
    }
}
