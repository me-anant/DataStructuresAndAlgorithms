using System;
using System.Collections;
using System.Linq;

namespace DataStructures.Lib
{
    public class MyStack : IEnumerable
    {
        private static object[] array;
        public int Count { get; set; } = 0;

        public MyStack()
        {
            array = new object[Count];
        }

        public MyStack(int capacity)
        {
            Count = capacity;
            array = new object[capacity];
        }

        public virtual void Push(object obj)
        {
            Count++;
            object[] oldArray = new object[Count];
            Array.Copy(array, 0, oldArray, 0, Count - 1);

            object[] newArray = new object[Count];
            array = newArray;

            array[0] = obj;
            Array.Copy(oldArray, 0, array, 1, Count - 1);
        }

        public virtual object Pop()
        {
            if (Count == 0) throw new InvalidOperationException("My stack or rather your stack is empty mate.");
            Count--;
            object[] newArray = new object[Count];
            var obj = array[0];
            Array.Copy(array, 1, newArray, 0, Count);
            array = newArray;
            return obj;
        }

        public virtual object Peek()
        {
            return array[0];
        }

        public virtual object[] ToArray()
        {
            return array;
        }

        public virtual bool Contains(object obj)
        {
            return array.Contains(obj);
        }

        public virtual void Clear()
        {
            Count = 0;
            array = new object[0];
        }

        public virtual IEnumerator GetEnumerator()
        {
            return array.AsEnumerable().GetEnumerator();
        }
    }
}
