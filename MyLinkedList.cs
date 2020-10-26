using System;

namespace Assignment7
{
    class MyNode<T>
    {
        public T Value { get; set; }
        public MyNode<T> Next { get; set; }
        public MyNode(T value)
        {
            Value = value;
            Next = null;
        }
    }

    class MyLinkedList<T>
    {
        public MyNode<T> First { get; set; }
        public MyLinkedList() { }

        public MyLinkedList(T[] values)
        {
            for (int i = values.Length - 1; i >= 0; i--)
                AddFirst(values[i]);
        }

        public void AddFirst(T value)
        {
            var node = new MyNode<T>(value);
            node.Next = First;
            First = node;
        }

        public void AddLast(T value)
        {
            var node = new MyNode<T>(value);
            if (First == null)
            {
                First = node;
                return;
            }

            var cur = First;
            for (; cur.Next != null; cur = cur.Next)
                continue;

            cur.Next = node;
        }

        public void Print()
        {
            for (var node = First; node != null; node = node.Next)
                Console.Write("-> {0} ", node.Value);
            Console.WriteLine();
        }
    }
}
