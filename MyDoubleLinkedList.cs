using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
    class MyDoubleNode<T>
    {
        public T Value { get; set; }
        public MyDoubleNode<T> Prev { get; set; }
        public MyDoubleNode<T> Next { get; set; }
        public MyDoubleNode(T value)
        {
            Value = value;
            Prev = Next = null;
        }
    }

    class MyDoubleLinkedList<T>
    {
        public MyDoubleNode<T> Root { get; set; }
        public MyDoubleLinkedList() { }

        public MyDoubleLinkedList(T[] values)
        {
            for (int i = values.Length - 1; i >= 0; i--)
                AddFirst(values[i]);
        }

        public void AddFirst(T value)
        {
            var node = new MyDoubleNode<T>(value);
            node.Next = Root;
            if (Root != null)
                Root.Prev = node;
            Root = node;
        }

        public void AddLast(T value)
        {
            var node = new MyDoubleNode<T>(value);
            if (Root == null)
            {
                Root = node;
                return;
            }

            var cur = Root;
            for (; cur.Next != null; cur = cur.Next)
                continue;

            cur.Next = node;
            node.Prev = cur;
        }

        public void Print()
        {
            for (var node = Root; node != null; node = node.Next)
                Console.Write("-> {0} ", node.Value);
            Console.WriteLine();
        }
    }
}
