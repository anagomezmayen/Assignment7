using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
    class Question10
    {
        /// <summary>
        /// Given a singly linked list of integers, Your task is to complete the function isPalindrome that 
        /// returns true if the given list is palindrome, else returns false.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        static public bool IsPalindrome(MyLinkedList<int> l)
        {
            if (l == null || l.First == null)
                return false;
            if (l.First.Next == null)
                return true;
            if (l.First.Next.Next == null)//only two elements on the list
                return (l.First.Value == l.First.Next.Value);


            var middle = l.First;
            var leader = l.First;
            int counter = 1;

            //looking for the middle node
            while (leader.Next != null)
            {
               

                leader = leader.Next;
                if (leader.Next != null)
                {
                    leader = leader.Next; //odd
                    middle = middle.Next; // if is even middle stays one behind
                }
                counter++;
            }
            if (counter % 2 == 0) //number of elements on the list is odd
            {
                var x = middle.Next;
                middle.Next = leader;
                ReverseNode(x);
                middle = middle.Next;
                counter--;
            }
          
            leader = l.First;
            while (middle != null)
            {
                if (leader.Value != middle.Value)
                    return false;
                middle = middle.Next;
                leader = leader.Next;
            }
            return true;
        }


        /// <summary>
        /// Reverse the second half of the list
        /// </summary>
        /// <param name="node"></param>

        static private void ReverseNode(MyNode<int> node)
        {
            MyNode<int> previous, current, next;
            previous = node;
            if (node.Next == null)//one element
                return;
            current = node.Next;
            if (current.Next == null)//two elements
            {
                current.Next = previous;
                previous.Next = null;
                return;
            }
            next = current.Next;

            while (next != null)
            {
                current.Next = previous;
                previous = current;
                current = next;
                next = next.Next;
            }
            current.Next = previous;
            node.Next = null;
           
        }

        //static public void Main(string[] args)
        //{
        //    int[] elem = { 1, 2, 3,0,3,2,1};
        //    MyLinkedList<int> listA = new MyLinkedList<int>(elem);
        //    listA.Print();
        //    Console.WriteLine(IsPalindrome(listA));

        //    int[] elem2 = { 1, 2, 3, 3, 2, 1 };
        //    MyLinkedList<int> listB = new MyLinkedList<int>(elem2);
        //    listB.Print();
        //    Console.WriteLine(IsPalindrome(listB));


        //}
    }

       
    }

