using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
    class Question1
    {
        /// <summary>
        /// Return the middle value of a linked list
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        static public int getMiddleElem(LinkedList<int> l)
        {
            LinkedListNode<int> middle = l.First;
            LinkedListNode<int> leader = l.First;

            //if the next element is null, the list has only one elem 

            while (leader.Next != null)
            {
                middle = middle.Next;

                leader = leader.Next;
                if(leader.Next!=null)
                    leader=leader.Next;
            }

            return middle.Value;
        }

        //static public void Main(string[] args)
        //{
        //    int[] elem = { 1, 2, 3, 4, 5};
        //    int[] elem2 = { 1, 2, 3, 4, 5, 6};

        //    LinkedList<int> myList = new LinkedList<int>(elem);
        //    LinkedList<int> myList2 = new LinkedList<int>(elem2);

        //    Console.WriteLine(getMiddleElem(myList));
        //    Console.WriteLine("\n");
        //    Console.WriteLine(getMiddleElem(myList2));

        //}
    }
}
