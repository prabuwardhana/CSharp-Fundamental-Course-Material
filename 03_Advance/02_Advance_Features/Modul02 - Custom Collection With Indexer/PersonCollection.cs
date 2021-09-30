using System.Collections;

namespace Indexer
{
    public class PersonCollection
    {
        private ArrayList people = new ArrayList();

        // Custom indexer for PersonCollection class.
        // This looks like any other C# property declaration 
        // apart from using this keyword.
        public Person this[int index]
        {
            // Return the correct object to the caller,
            // by delegating the request to the indexer of the ArrayList object (people)
            get => (Person)people[index];
            // Adding new Person objects
            set => people.Insert(index, value);
        }

        public int Count { get => people.Count; }
    }
}