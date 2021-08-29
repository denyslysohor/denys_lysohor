using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.DAL.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Delete(int id);
        void Update(T newItem, int id);
    }
}
