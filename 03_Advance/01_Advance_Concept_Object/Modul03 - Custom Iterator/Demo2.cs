using System;

namespace CustomIterator
{
    public class SimplePeople
    {
        // People is a collection of person
        private Person[] _personArray;

        public SimplePeople(Person[] personArray)
        {
            _personArray = new Person[personArray.Length];            

            for (int i = 0; i < personArray.Length; i++)
            {
                _personArray[i] = personArray[i];
            }
        }
    }

    public class Demo2
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

            SimplePeople peopleList = new SimplePeople(actress);

            // // this code will throw an Error!
            // // foreach statement cannot operate on variables of type 'SimplePeople'
            // // because 'SimplePeople' does not contain a public instance definition for 'GetEnumerator'
            // foreach (Person p in peopleList)
            // {
            //     Console.WriteLine("{0} {1}", p.firstName, p.lastName);
            // }
        }
    }
}