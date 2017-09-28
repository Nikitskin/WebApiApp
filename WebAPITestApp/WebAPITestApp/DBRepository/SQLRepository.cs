using System.Data.Entity;

namespace WebAPITestApp.DBRepository
{
    public class SQLRepository<T> : IDBRepository<T>
        where T : DbContext, new()
    {
        private T context;

        public SQLRepository()
        {
            context = new T();
        }

        public void Create(T item)
        {
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<T> GetAllItems()
        {
            throw new System.NotImplementedException();
        }

        public T GetItem(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
        public void Update(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}
