using System;

namespace ValRefType
{
    public class Person
    {
        public string personName;
        public int personAge;

        // Constructor.
        public Person(string name, int age)
        {
            personName = name;
            personAge = age;
        }
        public Person() { }

        public void Display()
        {
            Console.WriteLine("Nama: {0}, Umur: {1}", personName, personAge);
        }
    }
}