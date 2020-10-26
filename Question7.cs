using System;
using System.Collections.Generic;

namespace FlattenListStructs
{
   class Node<T>
   {
      public Node( T v )
      {
         Value = v;
         Next = null;
         Bottom = null;
      }
      public T Value { get; }
      public Node<T> Next { get; set; }
      public Node<T> Bottom { get; set; }
      public static bool operator <( Node<T> o1, Node<T> o2 ) { return Comparer<T>.Default.Compare( o1.Value, o2.Value ) < 0; }
      public static bool operator >( Node<T> o1, Node<T> o2 ) { return Comparer<T>.Default.Compare( o1.Value, o2.Value ) > 0; }
      public static bool operator <=( Node<T> o1, Node<T> o2 ) { return Comparer<T>.Default.Compare( o1.Value, o2.Value ) <= 0; }
      public static bool operator >=( Node<T> o1, Node<T> o2 ) { return Comparer<T>.Default.Compare( o1.Value, o2.Value ) >= 0; }
   }

   class ListHelpers<T>
   {
      public static Node<T> Merge( Node<T> l1, Node<T> l2 )
      {
         if( l1 == null ) return l2;
         if( l2 == null ) return l1;

         Node<T> res = null;
         Node<T> aux = null;
         while( l1 != null && l2 != null )
         {
            if( l1 < l2 )
            {
               if( res == null )
                  res = l1;
               else
                  aux.Next = l1;
               aux = l1;
               l1 = l1.Next;
            }
            else
            {
               if( res == null )
                  res = l2;
               else
                  aux.Next = l2;
               aux = l2;
               l2 = l2.Next;
            }
         }

         aux.Next = l1 ?? l2;
         return res;
      }

      public static void Flatten( Node<T> node )
      {
         var dummy = new Node<T>( node.Value ) { Bottom = node };
         Flatten_Rec( ref dummy );
      }

      private static void Flatten_Rec( ref Node<T> node )
      {
         if( node == null || node.Bottom == null ) return;

         // 1. 
         var nxt = node.Next;
         node.Next = node.Bottom;
         node.Bottom = null;

         // 2. 
         var prv = node;
         var cur = prv.Next;
         while( cur != null && ( nxt == null || cur <= nxt ) )
         {
            Flatten_Rec( ref cur );
            prv = cur;
            cur = cur.Next;
         }

         // 3. 
         prv.Next = nxt;
         if( nxt != null )
            nxt.Bottom = Merge( cur, nxt.Bottom );
      }

      public static void Print( Node<T> L )
      {
         for( var aux = L; aux != null; aux = aux.Next )
            Console.Write( " -> {0}", aux.Value );
         Console.WriteLine( " -> NIL" );
      }

      public static void PrintV( Node<T> L )
      {
         for( var aux = L; aux != null; aux = aux.Next )
         {
            Console.Write( " ║\n {0}", aux.Value );
            Print( aux.Bottom );
         }
         Console.WriteLine( " ║\n NIL" );
      }
   }

   class Program
   {
      //static void Main()
      //{
      //   Console.WriteLine("\n=========== EX 1 ===========\n");

      //   Node<int> L10 = new Node<int>( 10 );
      //   Node<int> L30 = new Node<int>( 30 ); L10.Next = L30;
      //   Node<int> L50 = new Node<int>( 50 ); L30.Next = L50;
      //   Node<int> L70 = new Node<int>( 70 ); L50.Next = L70;
      //   Node<int> L90 = new Node<int>( 90 ); L70.Next = L90;

      //   Node<int> L11 = new Node<int>( 11 ); L10.Bottom = L11;
      //   Node<int> L22 = new Node<int>( 22 ); L11.Next = L22;
      //   Node<int> L33 = new Node<int>( 33 ); L22.Next = L33;
      //   Node<int> L44 = new Node<int>( 44 ); L33.Next = L44;

      //   Node<int> L40 = new Node<int>( 40 ); L30.Bottom = L40;
      //   Node<int> L60 = new Node<int>( 60 ); L40.Next = L60;
      //   Node<int> L80 = new Node<int>( 80 ); L60.Next = L80;

      //   Node<int> L75 = new Node<int>( 75 ); L70.Bottom = L75;
      //   Node<int> L85 = new Node<int>( 85 ); L75.Next = L85;
      //   Node<int> L95 = new Node<int>( 95 ); L85.Next = L95;

      //   Node<int> L61 = new Node<int>( 61 ); L60.Bottom = L61;
      //   Node<int> L62 = new Node<int>( 62 ); L61.Next = L62;
      //   Node<int> L63 = new Node<int>( 63 ); L62.Next = L63;
      //   Node<int> L64 = new Node<int>( 64 ); L63.Next = L64;

      //   ListHelpers<int>.PrintV( L10 );
      //   Console.WriteLine( "\n\nAfter flattening:" );
      //   ListHelpers<int>.Flatten( L10 );
      //   ListHelpers<int>.Print( L10 );

      //   Console.WriteLine( "\n=========== EX 2 ===========\n" );

      //   Node<int> M05 = new Node<int>(  5 );
      //   Node<int> M10 = new Node<int>( 10 ); M05.Next = M10;
      //   Node<int> M19 = new Node<int>( 19 ); M10.Next = M19;
      //   Node<int> M28 = new Node<int>( 28 ); M19.Next = M28;

      //   Node<int> M07 = new Node<int>(  7 ); M05.Bottom = M07;
      //   Node<int> M08 = new Node<int>(  8 ); M07.Next = M08;
      //   Node<int> M30 = new Node<int>( 30 ); M08.Next = M30;

      //   Node<int> M20 = new Node<int>( 20 ); M10.Bottom = M20;
      //   //Node<int> M30_2 = new Node<int>( 30 ); M20.Next = M30_2;

      //   Node<int> M22 = new Node<int>( 22 ); M19.Bottom = M22;
      //   Node<int> M50 = new Node<int>( 50 ); M22.Next = M50;

      //   Node<int> M35 = new Node<int>( 35 ); M28.Bottom = M35;
      //   Node<int> M40 = new Node<int>( 40 ); M35.Next = M40;
      //   Node<int> M45 = new Node<int>( 45 ); M40.Next = M45;

      //   ListHelpers<int>.PrintV( M05 );
      //   Console.WriteLine("\n\nAfter flattening:");
      //   ListHelpers<int>.Flatten( M05 );
      //   ListHelpers<int>.Print( M05 );
      //}
   }
}
