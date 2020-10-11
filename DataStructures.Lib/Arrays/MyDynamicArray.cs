using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Lib.Arrays
{
    public class MyDynamicArray<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _capacity = 0;
        public int Length => _array.Length;

        public T this[int index]
        {
            get => _array[index];
            set => Set(index, value);
        }

        public MyDynamicArray()
        {
            _array = new T[_capacity];
        }

        public void Clear()
        {
            Array.Clear(_array, 0, Length);
            _capacity = 0;
            _array = new T[_capacity];
        }

        public void Add(T elem)
        {
            _capacity++;

            T[] newArray = new T[_capacity];
            for (int i = 0; i < Length; i++)
            {
                newArray[i] = _array[i];
            }

            newArray[_capacity - 1] = elem;
            _array = newArray;
        }

        public void Remove(T elem)
        {
            _capacity--;
            T[] newArray = new T[_capacity];

            int counter = 0;
            for (int i = 0; i < Length; i++)
            {
                if (elem.Equals(_array[i])) continue;

                newArray[counter] = _array[i];
                counter++;
            }

            _array = newArray;
        }

        public void RemoveAt(int index)
        {
            ThrowArgumentOutOfRangeExceptionIfIndexOutOfRange(index);

            Remove(_array[index]);
        }

        public bool Contains(T elem)
        {
            return IndexOf(elem) != -1;
        }

        public int IndexOf(T elem)
        {
            for (int i = 0; i < Length; i++)
            {
                if (elem.Equals(_array[i])) return i;
            }

            return -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _array.AsEnumerable().GetEnumerator();
        }

        private void ThrowArgumentOutOfRangeExceptionIfIndexOutOfRange(int index)
        {
            if (index > Length - 1 || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Index was out of range. Must be non negative and less than the size of the collection.");
        }

        private void Set(int index, T value)
        {
            ThrowArgumentOutOfRangeExceptionIfIndexOutOfRange(index);

            _array[index] = value;
        }
    }
}
