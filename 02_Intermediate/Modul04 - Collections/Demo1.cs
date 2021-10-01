using System;

namespace WorkingWithCollections
{
    public class Demo1
    {
        public static void Run()
        {
            string[] strArray = { "first", "second", "third" };

            Console.WriteLine("strArray has {0} elements:", strArray.Length);

            foreach (string s in strArray)
            {
                Console.WriteLine("{0} element", s);
            }

            // // Run-time error! IndexOutOfRangeException: Index was outside the bounds of the array.
            // // Array type is not expandable
            // strArray[3] = "fourth";

            int[] intArray = new int[5];
            Console.WriteLine("\nintArray has {0} elements:", intArray.Length);

            // it looks like intArray is an empty array, but...
            // surprisingly each element is filled by the default value of int (i.e. 0)
            foreach (int i in intArray)
            {
                Console.Write($"{i} ");
            }
        }
    }
}