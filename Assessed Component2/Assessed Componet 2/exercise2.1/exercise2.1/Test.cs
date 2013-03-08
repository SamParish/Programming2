using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise2._1
{
    class Test
    {
        public static void Main()
        {
            Console.WriteLine("Linked Queue test:");

            LinkedQueue<int> intQueueTest = new LinkedQueue<int>();
            intQueueTest.Enqueue(5);
            intQueueTest.Enqueue(4);
            intQueueTest.Enqueue(3);
            intQueueTest.Enqueue(2);
            intQueueTest.Enqueue(1);
            intQueueTest.Enqueue(0);

            Console.WriteLine("Peek at the head of the queue." + intQueueTest.Peek());
            Console.WriteLine(intQueueTest.Dequeue());
            Console.WriteLine(intQueueTest.Dequeue());
            Console.WriteLine(intQueueTest.Dequeue());
            Console.WriteLine(intQueueTest.Dequeue());
            Console.WriteLine(intQueueTest.Dequeue()); 
            Console.WriteLine(intQueueTest.Dequeue());

            Console.WriteLine("Array Queue test:");

            ArrayQueue<char> charQueueTest = new ArrayQueue<char>();

            charQueueTest.Enqueue('a');
            charQueueTest.Enqueue('b');
            charQueueTest.Enqueue('c');
            charQueueTest.Enqueue('d'); 
            charQueueTest.Enqueue('e');

            Console.WriteLine("Peek at the head of the queue." + charQueueTest.Peek());
            Console.WriteLine(charQueueTest.Dequeue());
            Console.WriteLine(charQueueTest.Dequeue());
            Console.WriteLine(charQueueTest.Dequeue());
            Console.WriteLine(charQueueTest.Dequeue());
            Console.WriteLine(charQueueTest.Dequeue());

            Console.ReadLine();
        }
    }
}
