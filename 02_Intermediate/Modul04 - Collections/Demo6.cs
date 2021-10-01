using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace WorkingWithCollections
{
    class ByFileExtension : IComparer<string>
    {
        string xExt, yExt;
        CaseInsensitiveComparer cip = new CaseInsensitiveComparer();

        public int Compare(string x, string y)
        {
            // Parse the extension from the file name. 
            xExt = x.Substring(x.LastIndexOf(".") + 1);
            yExt = y.Substring(y.LastIndexOf(".") + 1);

            // Compare the file extensions. 
            int vExt = cip.Compare(xExt, yExt);
            if (vExt != 0)
            {
                return vExt;
            }
            else
            {
                // The extension is the same, so compare the filenames.
                return cip.Compare(x, y);
            }
        }
    }
    
    public class Demo6
    {
        public static void Run()
        {
            // A SortedSet<T> object maintains a sorted order without affecting performance
            // as elements are inserted and deleted. Duplicate elements are not allowed. 
            // Changing the sort values of existing items is not supported and may lead to unexpected behavior.            

            int[] unsortedInt = { 1, 6, 8, 8, 3, 7, 9, 2, 2, 4 };
            // values in unsortedInt will be sorted,
            // duplicate value will be removed
            SortedSet<int> sortedSet = new SortedSet<int>(unsortedInt);

            foreach (int i in sortedSet)
            {
                Console.Write("{0} ", i);
            }

            // will be added and sorted
            sortedSet.Add(10);
            Console.WriteLine();

            foreach (int i in sortedSet)
            {
                Console.Write("{0} ", i);
            }            
        }

        public static void ListFileInDirectory()
        {
            void DisplayStringSet(IEnumerable<string> set)
            {
                foreach (string s in set)
                {
                    Console.WriteLine("\t{0} ", s);
                }
                Console.WriteLine("\n");
            }

            try
            {
                Console.Write("folder path: ");
                string dir = Console.ReadLine();

                // Get a list of the files to use for the sorted set.
                IEnumerable<string> files = Directory.EnumerateFiles(dir, "*", SearchOption.TopDirectoryOnly);

                // Create a sorted set using the ByFileExtension comparer.
                SortedSet<string> docFiles = new SortedSet<string>(new ByFileExtension());

                foreach (string f in files)
                {
                    docFiles.Add(f.Substring(f.LastIndexOf(@"\") + 1));
                }

                Console.WriteLine("ALL FILES: ");
                DisplayStringSet(docFiles);

                Console.WriteLine("PDF FILES: ");

                SortedSet<string> pdfFiles = docFiles.GetViewBetween("pde", "pdg");

                DisplayStringSet(pdfFiles);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}