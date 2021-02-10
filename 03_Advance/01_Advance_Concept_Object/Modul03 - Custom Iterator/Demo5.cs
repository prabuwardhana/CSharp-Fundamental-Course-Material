using System;
using System.Collections;

namespace CustomIterator
{
    public class People_A : IEnumerable
    {
        private Person[] _person;

        public People_A(Person[] pArray)
        {
            _person = new Person[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _person[i] = pArray[i];
            }
        }

        public IEnumerator GetEnumerator()
        {
            // Iterator Block
            foreach (Person p in _person)
            {
                // this will return a person to the caller's foreach construct
                // and stores the index of the current iteration in the container (array).
                // So, the next iteration will start from the next index of the array.
                yield return p;
            }
        }
    }
    public class Demo5
    {
        public static void Run()
        {
            Person[] actress = new Person[5]
            {
                new Person("Yui", "Aragaki"),
                new Person("Haruka", "Ayase"),
                new Person("Haruna", "kawaguchi"),
                new Person("Ishihara", "Satomi"),
                new Person("Mikako", "Tabe")
            };

            People_A peopleList = new People_A(actress);

            // Get each 'Person' in 'People' type
            foreach (Person p in peopleList)
            {
                Console.WriteLine("{0} {1}", p.firstName, p.lastName);
            }
        }
    }
}