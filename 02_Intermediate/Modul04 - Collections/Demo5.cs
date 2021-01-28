using System;
using System.Collections.Generic;

namespace WorkingWithCollections
{
    public class Demo5
    {
        public static void Run()
        {
            // The HashSet<T> class provides high-performance set operations. 
            // A set is a collection that contains no duplicate elements, 
            // and whose elements are in no particular order.

            void DisplayIntSet(IEnumerable<int> set)
            {
                Console.Write("[");
                foreach (int i in set)
                {
                    Console.Write(" {0} ", i);
                }
                Console.WriteLine("]");
            }

            HashSet<int> evenNumbers = new HashSet<int>();
            HashSet<int> oddNumbers = new HashSet<int>();

            for (int i = 0; i < 5; i++)
            {
                // Populate numbers with just even numbers.
                evenNumbers.Add(i * 2);
                // Populate oddNumbers with just odd numbers.
                oddNumbers.Add((i * 2) + 1);
            }

            Console.Write("'evenNumbers' terdiri dari {0} elemen: ", evenNumbers.Count);
            DisplayIntSet(evenNumbers);

            Console.Write("'oddNumbers' terdiri dari {0} elemen: ", oddNumbers.Count);
            DisplayIntSet(oddNumbers);

            // This line of code doesn't throw an error
            // Duplicated item will be simply ignored
            Console.WriteLine("\n=> Tambahkan angka '2' ke dalam set");
            evenNumbers.Add(2);
            // this will be added
            Console.WriteLine("=> Tambahkan angka '10' ke dalam set");
            evenNumbers.Add(10);
            Console.Write("'evenNumbers' terdiri dari {0} elemen: ", evenNumbers.Count);
            DisplayIntSet(evenNumbers);

            // Create a new HashSet populated with even numbers.
            HashSet<int> numbers = new HashSet<int>(evenNumbers);
            Console.Write("\n'numbers' UnionWith 'oddNumbers': ");
            numbers.UnionWith(oddNumbers);
            // HashSet is an unsorted set
            DisplayIntSet(numbers);

            // Contains() returns a boolean
            // Check if the hash table contains 0 and, if so, remove it.
            Console.WriteLine("\n=> Hapus angka '10' dari set");
            if (numbers.Contains(10))
            {
                numbers.Remove(10);
            }
            Console.Write("'numbers' terdiri dari {0} elemen: ", numbers.Count);
            DisplayIntSet(numbers);            

            Console.WriteLine("\n=> Hapus semua bilangan ganjil dari set");
            bool IsOdd(int i)
            {
                return ((i % 2) == 1);
            }
            // Remove all odd numbers.
            numbers.RemoveWhere(IsOdd);
            Console.Write("'numbers' terdiri dari {0} elemen: ", numbers.Count);
            DisplayIntSet(numbers);

            Console.WriteLine("\n=> Hapus semua elemen dari set");
            numbers.Clear();
            Console.WriteLine("=> hapus total semua objek 'numbers' dan lepas semua referensi ke objek tersebut");
            numbers.TrimExcess();

            Console.Write("'numbers' terdiri dari {0} elemen: ", numbers.Count);
            DisplayIntSet(numbers);
        }
    }
}