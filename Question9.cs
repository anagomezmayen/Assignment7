using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
    class Question9
    {
        /// <summary>
        /// Given two numbers represented by two lists, write a function that returns sum list. 
        /// The sum list is list representation of addition of two input numbers.
        /// Suppose you have two linked list 5->4 ( 4 5 )and 5->4->3( 3 4 5) you have to return  a resultant linked list 0->9->3 (3 9 0).
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        static public void SUM(MyLinkedList<int> l1, MyLinkedList<int> l2)
        {
            int carry = 0;
            int suma = 0;

            var current1 = l1.First;
            var current2 = l2.First;
            var previous1 = current1;
            var previous2 =current2;

            while (current1 !=null && current2!=null)
            {
                suma = current1.Value + current2.Value;
                current2.Value = (suma % 10)+carry;
                carry = suma / 10;

                previous1 = current1;
                current1 = current1.Next;
                
                previous2 = current2; //if list one has fewer number of elem
                current2 = current2.Next;
            }

            if (current1 == null && current2 !=null)
            {
                current2.Value += carry;
            }

            if (current1 != null && current2 == null)
            {
                current1.Value += carry;
                previous2.Next = current1;
                previous1.Next = null;
            }
            l1.First = null;
            l2.Print();

        }

        //static public void Main(string[] args)
        //{
        //    int[] elem1 = { 5, 4, 3, 1 };
        //    int[] elem2 = { 5, 4 };

        //    MyLinkedList<int> lista1 = new MyLinkedList<int>(elem1);
        //    MyLinkedList<int> lista2 = new MyLinkedList<int>(elem2);

        //    SUM(lista1, lista2);

        //    lista1.Print();
        //    lista2.Print();

        //    var x = lista2.First;
        //    int units = 1;
        //    int result = lista2.First.Value;
        //    while (x != null)
        //    {
        //        if(x.Value!=0)
        //            result += x.Value * units;

        //        units = units * 10;
        //        x = x.Next;
        //    }

        //    Console.WriteLine("result:{0}", result);
        //}
    }
}
