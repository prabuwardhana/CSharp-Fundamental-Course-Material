using System;

namespace SortingArrayOfObjects
{
    public class Demo3
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

            Console.WriteLine("\n==> Unsorted array:");
            foreach (Person a in actress)
            {
                Console.WriteLine("{0} {1}", a.firstName, a.lastName);
            }

            Console.WriteLine("\n==> Sort by 'First Name'");
            // // Sorting with comparer class (class that implements IComparer)
            Array.Sort(actress, new CompareFirstName());

            // // Menggunakan custom static property dan custom sort type
            Array.Sort(actress, Person.SortByFirstName);

            foreach (Person a in actress)
            {
                Console.WriteLine("{0} {1}", a.firstName, a.lastName);
            }

            Console.WriteLine("\n==> Sort by 'Last Name'");
            // // Sorting with comparer class (class that implements IComparer)
            // Array.Sort(actress, new CompareLastName());

            // // Mengurutkan dengan custom static property dan custom sort type
            Array.Sort(actress, Person.SortByLastName);

            foreach (Person a in actress)
            {
                Console.WriteLine("{0} {1}", a.lastName, a.firstName);
            }
        }
    }
}