using System;
using System.Collections;

namespace Modul15.IteratorMethodYield
{
    class Program
    {
        static void Main(string[] args)
        {
            // MenggunakanYieldReturn();
            MenggunakanLocalFunction();
            // MenggunakanCustomIteratorMethod();            
        }

        private static void MenggunakanLocalFunction()
        {
            Person[] actress = new Person[5];

            People peopleList = new People(actress);
            IEnumerator peopleEnum = peopleList.GetEnumerator();
        }

        private static void MenggunakanCustomIteratorMethod()
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

            // // Menggunakan custom iterator method
            // foreach (Person p in peopleList.GetThePerson())
            // {
            //     Console.WriteLine("{0} {1}", p.lastName, p.firstName);
            // }

            // Console.WriteLine("-> Balik urutan daftar ->");

            // foreach (Person p in peopleList.GetThePerson(true))
            // {
            //     Console.WriteLine("{0} {1}", p.lastName, p.firstName);
            // }
        }

        private static void MenggunakanYieldReturn()
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

            // Dapatkan setiap tipe 'Person' pada tipe 'People'
            foreach (Person p in peopleList)
            {
                Console.WriteLine("{0} {1}", p.firstName, p.lastName);
            }
        }        
    }
}
