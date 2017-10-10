using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBLayer.DBRepository
{                      
    public interface IDbRepository<T> 
        where T : class
    {
        Task<T> GetItem(int id); 
        void Create(T item); 
        void Update(T newItem); 
        void Delete(T item);
        Task<List<T>> GetAll();
    }
}
