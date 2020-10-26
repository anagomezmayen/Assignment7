using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
    class Question3
    {

   
        static public void ReverseKNodes(MyLinkedList<int> l, int k) //k>0
        {
            if (l == null || l.First == null)
            {
                Console.WriteLine("Empty list");
                return;
            }
            if (k == 1 || l.First.Next == null) //the result is the same list
            {
                return;
            }
            if (k == 2 && l.First.Next.Next == null)//k==2 and two element in the list, the result is the reversed list
            {
                ReverseList(l);
                return;
            }

            MyNode<int> leader = l.First; // this pointer is counting k nodes
            int counter = 1;
            bool firstChanged = false;

            MyNode<int> a = l.First, b = null, x = null;

            while (leader.Next != null && counter <= k)
            {
                if (counter == k)
                {

                    if (!firstChanged) //changing the head of the list
                    {
                        l.First = leader;
                        firstChanged = true;
                    }
                    b = leader;
                    leader = leader.Next;
                    ReverseNode(a, k);
                    if (x == null)
                    {
                        x = a;
                        
                    }
                    else
                    {
                        x.Next = b;
                        x = a;
                    }
                    a = leader;
                    counter = 1;
                }
                
                if (leader.Next == null)
                {
                    x.Next = a;
                }
                if (leader.Next.Next == null) { 
                    x.Next = leader.Next;
                    ReverseNode(a, k);
                    break;
                }
                leader = leader.Next;
                counter++;
            }
            
        }

        



        static private void ReverseList(MyLinkedList<int> l)
        {
            MyNode<int> previous, current, next;
            previous = null;
            current = l.First;
            next = current.Next;

            while (next != null)
            {
                
                current.Next = previous;
                previous = current;
                current = next;
                next = next.Next;
            }
            current.Next = previous;
            l.First = current;
        }

        static private void ReverseNode(MyNode<int> node, int k)
        {
            MyNode<int> previous, current, next;
            previous = node;
            current = node.Next;
            next = current.Next;

           
            if (next == null) //my node is the one before the last
            {
                current.Next = previous;
                previous.Next = null;
                return;
            }
            while(next!=null && k > 1){
                current.Next = previous;
                previous = current;
                current = next;
                next = next.Next;
                k--;
            }
            if (k > 1 && next==null)//current is the one before the last
            {
                node.Next = current.Next;
                current.Next = previous;
            }
        }



        //static public void Main(string[] args)
        //{
        //    int[] elem = { 1, 2, 3, 4, 5, 6, 7, 8,9,10};
        //    int[] elem2 = { 1, 2, 3, 4, 5, 6, 7,8};
        //    MyLinkedList<int> listA = new MyLinkedList<int>(elem);
        //    MyLinkedList<int> listB = new MyLinkedList<int>(elem2);

        //    ReverseKNodes(listA, 2);
        //    listA.Print();
        //    ReverseKNodes(listB, 3);
        //    listB.Print();
        //}
    }
}
