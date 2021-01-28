using System;
using System.Collections.Generic;

namespace AnonymousMethodLambda
{
    public class Demo5
    {
        public static void Run()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            Predicate<int> predicate = IsEvenNumber;
            List<int> evenNumber = list.FindAll(predicate);

            Console.Write("Daftar baru dengan bilangan genap: ");
            foreach (int i in evenNumber)
            {
                Console.Write("{0} ", i);
            }

            bool IsEvenNumber(int num)
            {
                return (num % 2) == 0;
            }
        }
    }
}