using System;

namespace SortingArrayOfObjects
{
    public class Demo2
    {
        public static void Run()
        {
            Person[] actress = new Person[5]
            {
                new Person("Ishihara", "Satomi"),
                new Person("Haruna", "kawaguchi"),
                new Person("Yui", "Aragaki"),
                new Person("Mikako", "Tabe"),
                new Person("Haruka", "Ayase")
            };

            Console.WriteLine("Before sorting:");
            foreach (Person a in actress)
            {
                Console.WriteLine("{0} {1}", a.firstName, a.lastName);
            }

            // Sorting actress array
            Array.Sort(actress);

            Console.WriteLine("\nAfter sorting:");
            foreach (Person a in actress)
            {
                Console.WriteLine("{0} {1}", a.firstName, a.lastName);
            }
        }
    }
}