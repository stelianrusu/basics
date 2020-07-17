using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings.WarmUp
{
    public class MyHashTable<TKey, TValue>
    {
        private const int DefaultSize = 32;
        private LinkedList<LinkedHashEntry<TKey, TValue>>[] values;

        public MyHashTable()
        {
            values = new LinkedList<LinkedHashEntry<TKey, TValue>>[DefaultSize];
        }

        public void Add(TKey key, TValue value)
        {
            var index = GetHashIndex(key);
            if(values[index] == null)
                values[index] = new LinkedList<LinkedHashEntry<TKey, TValue>>();

            values[index].AddLast(new LinkedHashEntry<TKey, TValue>(){Key = key, Value = value});
        }

        public TValue this[TKey key]
        {
            get
            {
                int index = GetHashIndex(key);
                var bucketList = values[index];
                foreach (var bucketItem in bucketList)
                {
                    if (bucketItem.Key.Equals(key))
                        return bucketItem.Value;
                }

                throw new KeyNotFoundException($"{key} not found");
            }
        }

        private int GetHashIndex(TKey key)
        {
            var hashCode = key.GetHashCode();
            int index = hashCode % values.Length;
            return index;
        }
    }

    class LinkedHashEntry<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
}
