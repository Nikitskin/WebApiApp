using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPITestApp.DBLayer.Contexts;
using WebAPITestApp.NLogger;

namespace WebAPITestApp.DBLayer.DBRepository
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
            await DbSet.AddAsync(item);
        }

        public virtual void Delete(T item)
        {
            DbSet.Remove(item);
        }

        public virtual async Task<T> GetItem(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual void Update(T item)
        {
            DbSet.Attach(item);
            Context.Entry(item).State = EntityState.Modified;
        }
    }
}
