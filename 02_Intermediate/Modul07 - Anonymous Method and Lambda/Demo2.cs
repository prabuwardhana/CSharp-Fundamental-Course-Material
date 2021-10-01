using System;
using System.Collections.Generic;

namespace AnonymousMethodLambda
{
    public class Demo2
    {
        public static void Run()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Instead of declaring a method that only used once,
            // We pass an anonymous method that match the predicate signature
            List<int> evenNumber = list.FindAll(
                delegate (int i)
                {
                    return (i % 2) == 0;
                }
            );

            Console.Write("New list contains only even numbers: ");
            foreach (int i in evenNumber)
            {
                Console.Write("{0} ", i);
            }

            /** OUTPUT **/
            /**********************************************
            # New list contains only even numbers: 20 4 8 44
            **********************************************/
        }
    }
}