using System;
using System.Collections;

namespace SortingArrayOfObjects
{
    public class CompareFirstName : IComparer
    {
        public int Compare(object x, object y)
        {
            Person p1 = x as Person;
            Person p2 = y as Person;
            if (p1 != null && p2 != null)
            {
                return String.Compare(p1.firstName, p2.firstName);
            }
            else
            {
                throw new ArgumentException("The parameter is not a type of 'Person'");
            }
        }
    }

    public class CompareLastName : IComparer
    {
        public int Compare(object x, object y)
        {
            Person p1 = x as Person;
            Person p2 = y as Person;
            if (p1 != null && p2 != null)
            {
                return String.Compare(p1.lastName, p2.lastName);
            }
            else
            {
                throw new ArgumentException("The parameter is not a type of 'Person'");
            }
        }
    }

    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        
        // Custom properties and custom sort type
        public static IComparer SortByFirstName
        {
            get
            {
                return (IComparer)new CompareFirstName();
            }
        }

        public static IComparer SortByLastName
        {
            get
            {
                return (IComparer)new CompareLastName();
            }
        }

        public Person(string fName, string lName)
        {
            firstName = fName;
            lastName = lName;
        }
    }
}