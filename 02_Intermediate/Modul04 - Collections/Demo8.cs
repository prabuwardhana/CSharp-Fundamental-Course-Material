using System;
using System.Collections.Generic;

namespace WorkingWithCollections
{
    public class Demo8
    {
        public static void Run()
        {
            // LIFO (Last In First Out)
            void DisplayStack(IEnumerable<string> queue)
            {
                Console.WriteLine("Elemen dalam tumpukan: ");
                foreach (string s in queue)
                {
                    Console.WriteLine("- {0}", s);
                }
            }

            Stack<string> numString = new Stack<string>();
            numString.Push("satu");
            numString.Push("dua");
            numString.Push("tiga");
            numString.Push("empat");
            numString.Push("lima");

            DisplayStack(numString);

            string num;
            num = numString.Pop();
            Console.WriteLine("\n=> Elemen '{0}' diambil dari tumpukan", num);
            DisplayStack(numString);
            Console.WriteLine("\nElemen yang akan diambil selanjutnya: '{0}'", numString.Peek());
            num = numString.Pop();
            Console.WriteLine("\n=> Elemen '{0}' diambil dari tumpukan", num);
            DisplayStack(numString);
        }
    }
}