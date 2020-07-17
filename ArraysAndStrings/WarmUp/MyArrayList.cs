using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings.WarmUp
{
    public class MyArrayList<T>
    {
        private T[] arr;
        private int windowSize;
        private int curArrayIndex;
        private int capacity;
        private const int DefaultSize = 100;

        private void initInternalArray(int size)
        {
            arr = new T[size];
            windowSize = size;
            capacity = size;
            curArrayIndex = -1;
        }

        public MyArrayList()
        {
            initInternalArray(DefaultSize);
        }

        
        public MyArrayList(int size)
        {
           initInternalArray(size);
        }

        public void Add(T item)
        {
            curArrayIndex++;
            if (curArrayIndex + 1 == capacity)
                increaseInternalArray();
            arr[curArrayIndex] = item;
        }

        public int Length => curArrayIndex + 1;

        private void increaseInternalArray()
        {
            capacity *= 2;
            T[] increasedArray = new T[capacity];
            arr.CopyTo(increasedArray, 0);
            arr = increasedArray;
        }

        public T this[int index] => arr[index];
    }
}
