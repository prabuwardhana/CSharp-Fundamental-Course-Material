using System;
using System.Collections;

namespace CustomIterator
{
    // IEnumerable needs System.Collections namespace
    public class CustomEnumerablePeople : IEnumerable
    {
        // People is a collection of person
        private Person[] _personArray;

        public CustomEnumerablePeople(Person[] personArray)
        {
            _personArray = new Person[personArray.Length];

            for (int i = 0; i < personArray.Length; i++)
            {
                _personArray[i] = personArray[i];
            }
        }

        // Work manually with IEnumerator
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        private PeopleEnumerator GetEnumerator()
        {
            return new PeopleEnumerator(_personArray);
        }
    }

    public class PeopleEnumerator : IEnumerator
    {
        public Person[] _person;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int Position = -1;

        public PeopleEnumerator(Person[] personArray)
        {
            _person = personArray;
        }

        public Person Current
        {
            get
            {
                return _person[Position];
            }
        }

        #region IEnumerator Implementation
        // object Current
        // {
        //     get
        //     {
        //         return Current;
        //     }
        // }

        // Get the current item (read-only property).
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        // Advance the internal position of the cursor.
        public bool MoveNext()
        {
            Position++;
            return (Position < _person.Length);
        }

        // Reset the cursor before the first member.
        public void Reset()
        {
            Position = -1;
        }
        #endregion        
    }

    public class Demo4
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

            CustomEnumerablePeople peopleList = new CustomEnumerablePeople(actress);

            // this code will not throw an Error!
            // 'CustomEnumerablePeople' implements IEnumerable interface
            foreach (Person p in peopleList)
            {
                Console.WriteLine("{0} {1}", p.firstName, p.lastName);
            }
        }
    }
}