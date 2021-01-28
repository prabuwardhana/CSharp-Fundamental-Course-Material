using System;

namespace WorkingWithCollections
{
    public class Demo1
    {
        public static void Run()
        {
            string[] strArray = { "Pertama", "Kedua", "Ketiga" };

            Console.WriteLine("strArray memiliki {0} elemen:", strArray.Length);

            foreach (string s in strArray)
            {
                Console.WriteLine("Elemen {0}", s);
            }

            // // Run-time error! IndexOutOfRangeException: Index was outside the bounds of the array.
            // // Array type is not expandable
            // strArray[3] = "Keempat";

            int[] intArray = new int[5];
            Console.WriteLine("\nintArray memiliki {0} elemen:", intArray.Length);

            // it looks like intArray is an empty array, but...
            // surprisingly each element is filled by the default value of int (i.e. 0)
            foreach (int i in intArray)
            {
                Console.Write($"{i} ");
            }
        }
    }
}