using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

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

        public async Task<T> GetItem(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public void Update(T newItem)
        {
            dbSet.AddOrUpdate(newItem);
        }
    }
}
