using System;
using System.Collections.Generic;

namespace WorkingWithCollections
{
    public class Demo7
    {
        public static void Run()
        {
            // This class implements a generic queue as a circular array. 
            // Objects stored in a Queue<T> are inserted at one end and removed from the other. 
            // FIFO (First In First Out)

            void DisplayQueue(IEnumerable<string> queue)
            {
                Console.Write("Elements in queue: ");
                foreach (string s in queue)
                {
                    Console.Write("'{0}' ", s);
                }
                Console.WriteLine();
            }

            Queue<string> numString = new Queue<string>();
            numString.Enqueue("one");
            numString.Enqueue("two");
            numString.Enqueue("three");
            numString.Enqueue("four");
            numString.Enqueue("five");

            // A queue can be enumerated without disturbing its contents.
            DisplayQueue(numString);

            string num;
            num = numString.Dequeue();
            Console.WriteLine("\n=> Element '{0}' is removed from the queue", num);
            DisplayQueue(numString);
            Console.WriteLine("\nElement that will be removed next: '{0}'", numString.Peek());
            num = numString.Dequeue();
            Console.WriteLine("\n=> Element '{0}' is removed from the queue", num);

            DisplayQueue(numString);
        }
    }
}