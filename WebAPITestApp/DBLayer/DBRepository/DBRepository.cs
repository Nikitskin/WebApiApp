using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBLayer.DBRepository
{
    public class DbRepository<T> : IDbRepository<T>
        where T : class, new()
    {
        private DbContext context;
        private DbSet<T> dbSet;

        public DbRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }

        public void Create(T item)
        {
            dbSet.Add(item);
        }

        public void Delete(T item)
        {
            dbSet.Remove(item);
        }

        public async Task<T> GetItem(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public void Update(T item)
        {
            dbSet.Update(item);
        }
    }
}
