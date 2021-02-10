using System;
using System.Collections;

namespace Modul15.IteratorMethodYield
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public Person(string fName, string lName)
        {
            firstName = fName;
            lastName = lName;
        }
    }

    #region Class 'People' implementing IEnumerable
    public class People : IEnumerable
    {
        private Person[] _person;

        public People(Person[] pArray)
        {
            _person = new Person[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _person[i] = pArray[i];
            }
        }

        // GetEnumerator() hanya akan dieksekusi pada pemanggilan MoveNext()
        public IEnumerator GetEnumerator()
        {
            // // Iterator Block
            // foreach (Person p in _person)
            // {
            //     yield return p;
            // }

            // // Dengan tidak dijalankannya kode program di bawah ini
            // // Akan menjadi masalah apabila kita ingin melakukan cek eror sebelum mengembalikan nilai pada setiap iterasi
            // if (_person[0] == null) throw new Exception("Array yang akan anda iterasi masih kosong");

            // for (int i = 0; i < _person.Length; i++)
            // {
            //     yield return _person[i];
            // }

            // Local function
            if (_person[0] == null) throw new Exception("Array yang akan anda iterasi masih kosong");

            return GetEnumeratorImpl();

            IEnumerator GetEnumeratorImpl()
            {
                foreach (Person p in _person)
                {
                    yield return p;
                }
            }
        }
    }
    #endregion

    // public class People
    // {
    //     private Person[] _people;

    //     public People(Person[] pArray)
    //     {
    //         _people = new Person[pArray.Length];

    //         for (int i = 0; i < pArray.Length; i++)
    //         {
    //             _people[i] = pArray[i];
    //         }
    //     }

    //     // Custom iterator method
    //     public IEnumerable GetThePerson()
    //     {
    //         if (_people[0] == null) throw new Exception("Array yang akan anda iterasi masih kosong");

    //         for (int i = 0; i < _people.Length; i++)
    //         {
    //             yield return _people[i];
    //         }
    //     }

    //     // Benefit: It allows us to pas arguments
    //     // Overload GetThePerson()
    //     public IEnumerable GetThePerson(bool returnReversed)
    //     {
    //         if (_people[0] == null) throw new Exception("Array yang akan anda iterasi masih kosong");

    //         if (returnReversed)
    //         {
    //             for (int i = _people.Length; i > 0; i--)
    //             {
    //                 yield return _people[i - 1];
    //             }
    //         }
    //         else
    //         {
    //             foreach (Person p in _people)
    //             {
    //                 yield return p;
    //             }
    //         }
    //     }
    // }
}