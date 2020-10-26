using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
    /// <summary>
    /// 
    /// 
    /// </summary>
    class Question6
    {
        static public MyLinkedList<int> Merge(MyLinkedList<int> a, MyLinkedList<int> b)
        {
            a.Print();
            b.Print();


            //vamos arevisar cada lista y poner los elementos en la lista que tenga el elemento m[as pequeli

            MyNode<int> x;
            
            if (b.First.Value <= a.First.Value)
            {
                x = b.First;
                b.First = b.First.Next;
                x.Next = a.First;
                a.First = x;
            }

            var current = a.First;

            while (b.First != null && current.Next != null)
            {

                if (b.First.Value < current.Next.Value)
                {
                    x = b.First;
                    b.First = b.First.Next;

                    x.Next = current.Next;
                    current.Next = x;
                }
                current = current.Next;
            }
            if (b.First != null)// this element should be at the end of a
            {
                current.Next = b.First;
                b.First = null;
            }
            Console.Write("List 1: ");
            a.Print();
            Console.Write("List 2: ");
            b.Print();
            return a;

        }

        //static public void Main(string[] args)
        //{
        //    int[] elem = { 0, 1, 4, 5, 6, 9, 11, 12 };
        //    int[] elem2 = { 0, 2, 3, 7, 8, 10 };
        //    MyLinkedList<int> listA = new MyLinkedList<int>(elem);
        //    MyLinkedList<int> listB = new MyLinkedList<int>(elem2);

        //    Merge(listA, listB);
        //}
    }
}
