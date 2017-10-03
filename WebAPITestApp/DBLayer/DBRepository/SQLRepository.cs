using DBLayer.Contexts;
using System.Data.Entity;

namespace DBLayer.DBRepository
{
    public class SQLRepository<T> : IDBRepository<T>
        where T : class, new()
    {
        private OrderContext context;
        private DbSet<T> dbSet;

        public SQLRepository()
        {
            context = new OrderContext();
            dbSet = context.Set<T>();
        }

        public void Create(T item)
        {
            dbSet.Add(item);
            context.SaveChanges();
        }

        public void Delete(T item)
        {
            dbSet.Remove(item);
        }

        public void Dispose()
        {
            context.Dispose();
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
