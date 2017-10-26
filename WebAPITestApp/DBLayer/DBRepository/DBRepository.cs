using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBLayer.DBRepository
{
    public class DbRepository<T> : IDbRepository<T>
        where T : class, new()
    {
        protected DbContext Context;
        protected DbSet<T> DbSet;

        public DbRepository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public virtual void Create(T item)
        {
            DbSet.Add(item);
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
            DbSet.Update(item);
        }
    }
}
