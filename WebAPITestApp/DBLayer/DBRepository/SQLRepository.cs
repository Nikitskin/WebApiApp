using System.Data.Entity;

namespace WebAPITestApp.DBRepository
{
    public class SQLRepository<T> : IDBRepository<T>
        where T : class, new()
    {
        private DbContext context;
        private DbSet<T> dbSet;

        public SQLRepository(string connectionName)
        {
            context = new DbContext(connectionName);
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

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public T GetItem(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(T item, T newItem)
        {
            dbSet.Remove(item);
            dbSet.Add(newItem);
        }
    }
}
