using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
    class Question8
    {

        static public void SwapPairwise(MyLinkedList<int> l)
        {
            Console.WriteLine("Original list: ");
            l.Print();
            var a = l.First;
            if (l == null || a.Next == null)
                return;
            
            l.First = a.Next;

            //list with 2 elements
            if (a.Next.Next == null)
            {
                a.Next.Next = a;
                a.Next = null;
                return;
            }

            //for more than 2 elements. A and B in position

            var b = a.Next.Next;

            while (a.Next.Next != null)
            {
                a.Next.Next = a;
                if (b.Next == null) // odd number of elements
                {
                    a.Next = b;
                    break;
                }
                a.Next = b.Next;
                if (b.Next.Next == null)// even number of elements
                {
                    b.Next.Next = b;
                    b.Next = null;
                    break;
                }
                a = b;
                b = a.Next.Next;               
            }
        }

        static public void Main()
        {
            int[] elem = { 1, 2, 3, 4, 5 };
            MyLinkedList<int> list = new MyLinkedList<int>(elem);
           
            SwapPairwise(list);
            list.Print();
        }
    }
}
