﻿using System;
using System.Collections.Generic;

namespace WebAPITestApp.DBRepository
{
    public interface IDBRepository<T> :IDisposable where T : class
    {
        T GetItem(int id); 
        void Create(T item); 
        void Update(T item, T newItem); 
        void Delete(T item); 
    }
}
