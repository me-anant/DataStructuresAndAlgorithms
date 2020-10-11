namespace DataStructures.Lib.Classes
{
    public class MyLinkedListNode<T>
    {
        public MyLinkedListNode<T> Previous { get; set; }
        public MyLinkedListNode<T> Next { get; set; }
        public T Value { get; set; }

        public MyLinkedListNode(T value)
        {
            Value = value;
        }
    }
}
