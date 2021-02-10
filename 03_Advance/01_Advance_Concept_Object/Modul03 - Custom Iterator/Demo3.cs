using System;
using System.Collections;

namespace CustomIterator
{
    // IEnumerable needs System.Collections namespace
    public class EnumerablePeople : IEnumerable
    {
        // People is a collection of person
        private Person[] _personArray;

        public EnumerablePeople(Person[] personArray)
        {
            _personArray = new Person[personArray.Length];

            for (int i = 0; i < personArray.Length; i++)
            {
                _personArray[i] = personArray[i];
            }
        }

        /* implementation of GetEnumerator() */
        // // As the System.Array type (as well as many other collection classes) already implements IEnumerable 
        // // and IEnumerator, we can simply delegate the request to the System.Array as follows
        public IEnumerator GetEnumerator()
        {
            return _personArray.GetEnumerator();
        }       
    }    
    
    public class Demo3
    {
        public static void Run()
        {
            Person[] actress = new Person[5]
            {
                new Person("Yui", "Aragaki"),
                new Person("Haruka", "Ayase"),
                new Person("Haruna", "kawaguchi"),
                new Person("Mikako", "Tabe"),
                new Person("Ishihara", "Satomi")
            };

            EnumerablePeople peopleList = new EnumerablePeople(actress);

            // this code will not throw an Error!
            // 'EnumerablePeople' implements IEnumerable interface
            foreach (Person p in peopleList)
            {
                Console.WriteLine("{0} {1}", p.firstName, p.lastName);
            }
        }
    }
}