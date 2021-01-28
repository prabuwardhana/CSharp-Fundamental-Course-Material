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
                Console.Write("Elemen dalam antrian: ");
                foreach (string s in queue)
                {
                    Console.Write("'{0}' ", s);
                }
                Console.WriteLine();
            }

            Queue<string> numString = new Queue<string>();
            numString.Enqueue("satu");
            numString.Enqueue("dua");
            numString.Enqueue("tiga");
            numString.Enqueue("empat");
            numString.Enqueue("lima");

            // A queue can be enumerated without disturbing its contents.
            DisplayQueue(numString);

            string num;
            num = numString.Dequeue();
            Console.WriteLine("\n=> Elemen '{0}' diambil dari antrian", num);
            DisplayQueue(numString);
            Console.WriteLine("\nElemen yang akan diambil selanjutnya: '{0}'", numString.Peek());
            num = numString.Dequeue();
            Console.WriteLine("\n=> Elemen '{0}' diambil dari antrian", num);

            DisplayQueue(numString);
        }
    }
}