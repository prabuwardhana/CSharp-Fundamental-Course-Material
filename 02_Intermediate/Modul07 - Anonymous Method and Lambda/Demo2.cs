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

            List<int> evenNumber = list.FindAll(
                delegate (int i)
                {
                    return (i % 2) == 0;
                }
            );

            Console.Write("Daftar baru dengan bilangan genap: ");
            foreach (int i in evenNumber)
            {
                Console.Write("{0} ", i);
            }
        }
    }
}