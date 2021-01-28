using System;
using System.Collections.Generic;

namespace AnonymousMethodLambda
{
    public class Demo1
    {
        public static void Run()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // list.FindAll(Predicate<int> match);
            /********************************************************************
            # => public List<T> FindAll(Predicate<T> match);
            # This delegate type can point to any method returning a bool and takes a single type parameter 
            # as the only input parameter.
            # => public delegate bool Predicate<[NullableAttribute(2)] in T>(T obj);
            ********************************************************************/

            Predicate<int> predicate = IsEvenNumber;
            List<int> evenNumber = list.FindAll(predicate);

            Console.Write("Daftar baru dengan bilangan genap: ");
            foreach (int i in evenNumber)
            {
                Console.Write("{0} ", i);
            }
        }

        private static bool IsEvenNumber(int num)
        {
            return (num % 2) == 0;
        }
    }
}