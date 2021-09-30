using System.Collections;
using System.Collections.Generic;

namespace Indexer
{
    public class PersonDictionary : IEnumerable
    {
        private Dictionary<string, Person> listPeople = new Dictionary<string, Person>();

        public Person this[string name]
        {
            get => (Person)listPeople[name];
            set => listPeople[name] = value;
        }

        public void ClearPeople()
        {
            listPeople.Clear();
        }

        public IEnumerator GetEnumerator() => listPeople.GetEnumerator();

        public int Count => listPeople.Count;
    }
}