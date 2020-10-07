using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Lib.Stacks
{
    public class SentiStack : IEnumerable
    {
        LinkedList<object> lList = new LinkedList<object>();
        public int Count { get => lList.Count; }

        public void Push(object obj) => lList.AddFirst(obj);

        public object Pop()
        {
            var temp = lList.First.Value;
            lList.RemoveFirst();
            return temp;
        }

        public object Peek() => lList.First.Value;

        public object[] ToArray() => lList.ToArray();

        public bool Contains(object obj) => lList.Contains(obj);

        public void Clear() => lList.Clear();

        public IEnumerator GetEnumerator()
        {
            return lList.AsEnumerable().GetEnumerator();
        }
    }
}
