using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
    class Question5
    {
        /// <summary>
        /// Given a linked list, the task is to find the n'th node from the end.
        /// </summary>
        /// <returns></returns>
        static public MyNode<int> GetNthNodeFromEnd1(MyLinkedList<int> l, int n)
        {
            if (l == null || n <= 0) {
                Console.WriteLine("Invalid value");
                return null;
            }
            int length = 0;
            var current = l.First;

            for (; current.Next != null; current = current.Next) { 
                length++;
            }
            current = l.First;

            if (n == length + 1)
                return l.First;
           
            if (n > length)
            {
                Console.WriteLine("Invalid value: n is outrange");
                return null;
            }                
            for(int i=0; i <= length - n; i++)
            {
                current = current.Next;
            }

            return current;
        }

        static public MyNode<int> GetNthNodeFromEnd(MyLinkedList<int> l, int n)
        {
            if (l == null || n <= 0)
            {
                Console.WriteLine("invalid value");
                return null;
            }
            var last = l.First;
            var current = last;
            for(int i = 1; i < n; i++)
            {
                if (last.Next == null)
                {
                    Console.WriteLine("Invaid value: n is outrange");
                    return null;
                }
                last = last.Next;
            }
            while (last.Next != null)
            {
                last = last.Next;
                current = current.Next;
            }
            return current;
        }




        //static public void Main()
        //{
        //    int[] elem = { 1, 2, 3, 4, 5, 6 };
        //    MyLinkedList<int> list = new MyLinkedList<int>(elem);
        //    list.Print();

        //    MyLinkedList<int> result = new MyLinkedList<int>();
        //    result.First = GetNthNodeFromEnd(list, 3);
        //    result.Print();
        //}
    }
}
