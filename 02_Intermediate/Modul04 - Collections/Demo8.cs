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
                Console.WriteLine("Element in the stack: ");
                foreach (string s in queue)
                {
                    Console.WriteLine("- {0}", s);
                }
            }

            Stack<string> numString = new Stack<string>();
            numString.Push("one");
            numString.Push("two");
            numString.Push("three");
            numString.Push("four");
            numString.Push("five");

            DisplayStack(numString);

            string num;
            num = numString.Pop();
            Console.WriteLine("\n=> Element '{0}' is removed from stack", num);
            DisplayStack(numString);
            Console.WriteLine("\nElement that will be removed next: '{0}'", numString.Peek());
            num = numString.Pop();
            Console.WriteLine("\n=> Element '{0}' is removed from stack", num);
            DisplayStack(numString);
        }
    }
}