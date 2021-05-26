using System;
namespace DataStorage
{
        public interface IDataStore<T>
        {
            void Add(T item);
            void Remove(T item);
            int Count { get; }
            T[] Items { get; }
        }
}
