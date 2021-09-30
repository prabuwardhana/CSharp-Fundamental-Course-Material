using System;

namespace Indexer
{
    public class Demo3
    {
        public static void Run()
        {
            PersonDictionary myPeople = new PersonDictionary();
            myPeople["Homer"] = new Person("Homer", "Simpson", 40);
            myPeople["Marge"] = new Person("Marge", "Simpson", 38);
            
            // Get "Homer" and print data.
            Person homer = myPeople["Homer"];
            Console.WriteLine(homer.ToString());
        }
    }
}