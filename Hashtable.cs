using System;

namespace Hashtable
{
    public class HashTable<K, T> where K : IComparable<K> where T : IComparable<T>
    {
        private HashNode<K, T>[] _buckets;

        private const double STANDARD_LOADING = 0.75;
        private const int STANDARD_CAPACITY  = 40;

        private readonly double _loading;
        private int _threshold;
        private int _count;
        public int Count => _count;

        public HashTable(double loading, int capacity)
        {
            loading = STANDARD_LOADING;
            capacity = STANDARD_CAPACITY;

            _loading = loading;
            _buckets = new HashNode<K, T>[capacity];
            _threshold = (int) (capacity * loading);
        }

        public bool ContainsKey(K key)
        {
            int index = Hash(key);
            var item = _buckets[index];

            if (item.Equals(null))
            {
                return false;
            }

            while (item != null)
            {
                if (item.Key.CompareTo(key) == 0)
                {
                    return true;
                }

                item = item.Next;
            }

            return false;
        }

        public bool ContainsValue(T value)
        {
            foreach (var bucket in _buckets)
            {
                if (bucket.Equals(null))
                {
                    continue;
                }

                var item = bucket;
                while (item != null)
                {
                    if (item.Value.CompareTo(value) == 0)
                    {
                        return true;
                    }

                    item = item.Next;
                }
            }
            
            return false;
        }

        public T Find(K key)
        {
            throw new NotImplementedException();
        }

        public void Add(K key, T value)
        {
            int index = Hash(key);
            var bucket = _buckets[index];
            while (bucket != null)
            {
                if (key.CompareTo(bucket.Key) == 0)
                {
                    bucket.Value = value;
                    return;
                }

                bucket = bucket.Next;
                
            }

            if (_count + 1 > _threshold)
            {
                ReHash();
                index = Hash(key);
            }

            var item = new HashNode<K, T>(key, value);
            item.Next = _buckets[index];
            _buckets[index] = item;
            _count++;
        }

        public void Remove(K key)
        {
            int index = Hash(key);
            var bucket = _buckets[index];
            HashNode<K, T> last = null;
            while (bucket != null)
            {
                if (bucket.Key.CompareTo(key) == 0)
                {
                    _count--;
                    if (last == null)
                    {
                        _buckets[index] = bucket.Next;
                    }
                    else
                    {
                        last.Next = bucket.Next;
                    }

                    last = bucket;
                    bucket = bucket.Next;
                }
            }
        }

        private int Hash(K key)
        {
            return key == null ? 0 : Math.Abs(key.GetHashCode() % _buckets.Length);
        }

        private void ReHash()
        {
            var oldBuckets = _buckets;
            int newCapacity = _buckets.Length * 2 + 1;
            _threshold = (int) (newCapacity * _loading);
            _buckets = new HashNode<K, T>[newCapacity];

            foreach (var oldBucket in oldBuckets)
            {
                var currentNode = oldBucket;
                while (currentNode != null)
                {
                    int index = Hash(currentNode.Key);
                    var node = new HashNode<K, T>(currentNode.Key, currentNode.Value);
                    node.Next = _buckets[index];
                    _buckets[index] = node;
                    currentNode = currentNode.Next;
                }
            }
        }
    }
}
