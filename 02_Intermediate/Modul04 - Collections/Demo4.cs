using System;
using System.Collections.Generic;

namespace WorkingWithCollections
{
    public class Demo4
    {
        public static void Run()
        {
            // The Dictionary<TKey,TValue> generic class provides a mapping from a set of keys to a set of values. 
            // Each addition to the dictionary consists of a value and its associated key.
            // Retrieving a value by using its key is very fast, close to O(1), 
            // because the Dictionary<TKey,TValue> class is implemented as a hash table.            

            // initialization syntax
            Dictionary<string, string> openWith = new Dictionary<string, string>
            {
                {"txt", "notepad.exe"},
                {"bmp", "paint.exe"},
                {"png", "paint.exe"},
                {"rtf", "wordpad.exe"}
            };

            // ArgumentException: An item with the same key has already been added. Key: txt
            // openWith.Add("txt", "winword.exe");

            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Element with key = \"txt\" already exist");
            }

            // Accessing element
            Console.WriteLine("Value for key \"rtf\" = {0}", openWith["rtf"]);

            // The indexer can be used to change the value associated with a key.
            Console.WriteLine("=> Change the value of element with key \"rtf\"");
            openWith["rtf"] = "winword.exe";
            Console.WriteLine("Current value of key \"rtf\" = {0}", openWith["rtf"]);

            // If a key does not exist, setting the indexer for that key adds a new key/value pair.
            openWith["doc"] = "winword.exe";

            // // The indexer throws an exception if the requested key is not in the dictionary.
            // // KeyNotFoundException: The given key 'tif' was not present in the dictionary.
            // Console.WriteLine("Nilai untuk kunci \"tif\" = {0}", openWith["tif"]);

            try
            {
                Console.WriteLine("Value of key \"tif\" = {0}", openWith["tif"]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Key = \"tif\" not found!");
            }

            // When a program often has to try keys that turn out not to be in the dictionary,
            // TryGetValue() can be a more efficient way to retrieve values.
            string value = "";
            if (openWith.TryGetValue("tif", out value))
            {
                Console.WriteLine("Value of key \"tif\" = {0}", value);
            }
            else
            {
                Console.WriteLine("Key = \"tif\" not found!");
            }

            // ContainsKey can be used to test keys before inserting them.
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Console.WriteLine("A key \"ht\" has been added with value: {0}", openWith["ht"]);
            }

            // When you use foreach to enumerate dictionary elements, 
            // the elements are retrieved as KeyValuePair objects.
            Console.WriteLine("\nkey-value pair:");
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("\tKey = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

            // To get the values alone, use the Values property.
            Dictionary<string, string>.KeyCollection keyColl = openWith.Keys;            

            Console.WriteLine(keyColl.GetType());

            // The elements of the KeyCollection are strongly typed
            // with the type that was specified for dictionary keys.
            Console.WriteLine("\nList of key in 'openWith' collection:");
            foreach (string s in keyColl)
            {
                Console.WriteLine("\tkey = {0}", s);
            }

            // To get the values alone, use the Values property.
            Dictionary<string, string>.ValueCollection vallColl = openWith.Values;

            // The elements of the ValueCollection are strongly typed
            // with the type that was specified for dictionary values.
            Console.WriteLine("\nList of value in 'openWith' collection:");
            foreach (string s in vallColl)
            {
                Console.WriteLine("\tValue = {0}", s);
            }

            Console.WriteLine("\n=> Remove element with key (\"doc\")");
            openWith.Remove("doc");

            Console.WriteLine("\n=> Find element with key (\"doc\")");
            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("Element with key \"doc\" not found!");
            }
        }
    }
}