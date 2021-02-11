using System;

namespace SortingArrayOfObjects
{
    public class Demo1
    {
        public static void Run()
        {
            int[] intArray = { 10, 90, 70, 50, 30, 20, 40, 60, 80, 100 };

            Console.WriteLine("Sebelum diurutkan:");
            foreach (int i in intArray)
            {
                Console.Write("{0} ", i);
            }
            
            Array.Sort(intArray);
            
            Console.WriteLine("\n\nSetelah diurutkan:");
            foreach (int i in intArray)
            {
                Console.Write("{0} ", i);
            }
        }
    }
}