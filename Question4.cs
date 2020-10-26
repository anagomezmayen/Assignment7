using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
    class Question4
    {
        /// <summary>
        /// Given a linked list, check if the the linked list has a loop. Linked list can contain self loop.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        static public bool HasLoop(MyLinkedList<int> l)
        {
            var oneSteps = l.First;
            var twoSteps = l.First.Next;

            while (oneSteps!=null && twoSteps!=null)
            {
                if (oneSteps.Value == twoSteps.Value)
                    return true;
                oneSteps = oneSteps.Next;
                twoSteps = twoSteps.Next;
                if (twoSteps.Next == null)
                    return false;
                twoSteps = twoSteps.Next;
            }

            return false;
        }

        //static public void Main(string[] args)
        //{
        //    int[] elem = { 1, 2, 3, 4, 3 };
        //    MyLinkedList<int> ml = new MyLinkedList<int>(elem);
        //    var x = ml.First;

        //    for (int i = 1; i < 3; i++)
        //    {
        //        x = x.Next;
        //    }

        //   // x.Next = ml.First;

        //    ml.Print();

        //    Console.WriteLine(HasLoop(ml));

        //}

    }
}
