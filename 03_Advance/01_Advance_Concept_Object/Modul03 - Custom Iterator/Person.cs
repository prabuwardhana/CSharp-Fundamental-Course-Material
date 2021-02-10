using System.Collections;

namespace CustomIterator
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
}