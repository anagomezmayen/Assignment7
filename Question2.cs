using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
  
    class Question2
    {
        /// <summary>
        /// Given a singly linked list, rotate the linked list counter-clockwise by k nodes. Where k is a given positive integer smaller than or equal to length of the linked list.
        /// For example, if the given linked list is 10->20->30->40->50->60 and k is 4, the list should be modified to 50->60->10->20->30->40.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="k"></param>
        static public void RotateKNodes(MyLinkedList<int> list, int k)
        {
            if (list == null || k <= 0)
                return;

            var last = list.First;
            var cur = last;
            if (last == null)
                return;
  
            for (; last.Next != null; last = last.Next)
            {
                if (k > 0)
                {
                    cur = last;
                    k--;
                }
            }


            if (k == 0)
            {
                last.Next = list.First;
                list.First = cur.Next;
                cur.Next = null;
            }
        }

      
        //static public void Main()
        //{
        //    int[] elem = { 20, 30, 40, 50, 60 };
        //    MyLinkedList<int> list = new MyLinkedList<int>(elem);
        //    list.AddFirst(10);
        //    list.AddLast(70);
        //    list.Print();

        //    RotateKNodes(list, 4);
        //    list.Print();
        //}
    }
}
