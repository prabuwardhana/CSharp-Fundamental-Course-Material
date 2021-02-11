using System;

namespace SortingArrayOfObjects
{
    public class ComparablePerson : IComparable
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public ComparablePerson(string fName, string lName)
        {
            firstName = fName;
            lastName = lName;
        }

        public int CompareTo(object obj)
        {
            Person temp = obj as Person;

            if (temp != null)
            {
                // Sorting by firstName
                return String.Compare(this.firstName, temp.firstName);
            }
            else
            {
                throw new ArgumentException("Parameter is not a 'Person'!");
            }
        }
    }
}