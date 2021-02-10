using System;
using System.Collections;

namespace CustomIterator
{
    public class People
    {
        private Person[] _people;

        public People(Person[] pArray)
        {
            _people = new Person[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _people[i] = pArray[i];
            }
        }

        // Custom named iterator method
        public IEnumerable GetThePerson()
        {
            if (_people.Length == 0) throw new Exception("You cannot iterate an empty array!");

            for (int i = 0; i < _people.Length; i++)
            {
                yield return _people[i];
            }
        }

        // Benefit: It allows us to pas arguments
        // Overload GetThePerson()
        public IEnumerable GetThePerson(bool returnReversed)
        {
            if (_people.Length == 0) throw new Exception("You cannot iterate an empty array!");

            if (returnReversed)
            {
                for (int i = _people.Length; i > 0; i--)
                {
                    yield return _people[i - 1];
                }
            }
            else
            {
                foreach (Person p in _people)
                {
                    yield return p;
                }
            }
        }
    }

    public class Demo6
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

            People peopleList = new People(actress);

            // Using custom iterator method
            foreach (Person p in peopleList.GetThePerson())
            {
                Console.WriteLine("{0} {1}", p.lastName, p.firstName);
            }

            Console.WriteLine("-> Balik urutan daftar ->");

            foreach (Person p in peopleList.GetThePerson(true))
            {
                Console.WriteLine("{0} {1}", p.lastName, p.firstName);
            }
        }
    }
}