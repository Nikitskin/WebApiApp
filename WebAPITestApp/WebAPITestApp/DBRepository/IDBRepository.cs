using System;
using System.Collections.Generic;

namespace WebAPITestApp.DBRepository
{
    interface IDBRepository<T> :IDisposable where T : class
    {
        IEnumerable<T> GetAllItems();
        T GetItem(int id); 
        void Create(T item); 
        void Update(T item); 
        void Delete(int id); 
        void Save();
    }
}
