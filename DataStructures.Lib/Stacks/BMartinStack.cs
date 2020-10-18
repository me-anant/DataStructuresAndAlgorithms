using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Lib.Stacks
{
    public class BMartinStack : IEnumerable
    {
        private LinkedList<object> list;

        public BMartinStack()
        {
            list = new LinkedList<object>();
        }

        public void Push(object obj)
        {
            list.AddFirst(obj);
        }

        public object Pop()
        {
            var ToReturn = list.First.Value;
            list.RemoveFirst();
            return ToReturn;
        }

        public object Peek()
        {
            return list.First.Value;
        }

        public object[] ToArray()
        {
            return list.ToArray();
        }

        public bool Contains(object obj)
        {
            return list.Contains(obj);
        }

        public void Clear()
        {
            list.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return list.AsEnumerable().GetEnumerator();
        }
    }
}