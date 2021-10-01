using System;
using System.Collections.Generic;

namespace WorkingWithCollections
{
    public class Demo3
    {
        public static void Run()
        {
            // local function for displaying list elements
            void DisplayIntList(IEnumerable<int> intList)
            {
                Console.Write("[");
                foreach (int item in intList)
                {
                    Console.Write($" {item} ");
                }
                Console.WriteLine("]");
            }

            // Declare a generic collection which contains only integer value
            List<int> intList = new List<int>();

            // The values are all allocated in the stack
            intList.Add(10);
            intList.Add(20);
            intList.Add(30);
            intList.Add(40);
            intList.Add(50);

            /**********************************************
            # List<T> solves the issue of type safety.
            # In our case, we have declared intList as List of int (List<int>)
            # consequently intList only accept int
            **********************************************/
            // // Error! Argument '1' cannot convert from 'bool' to 'int'
            // intList.Add(true);
            // // Error! Argument '1' cannot convert from 'bool' to 'int'
            // intList.Add(5.7);

            DisplayIntList(intList);

            // Remove() returns true or false
            if (intList.Remove(60))
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Fail");
            }

            // RemoveAt() returns void
            // Throw an ArgumentOutOfRangeException if it can't find the index
            try
            {
                intList.RemoveAt(6);
                DisplayIntList(intList);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // RemoveRange() returns void
            // Throw an ArgumentException if it fails
            try
            {
                intList.RemoveRange(2, 10);
                DisplayIntList(intList);                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // local function used as predicate
            bool IsMoreThan70(int i)
            {
                return i > 70;
            }

            int numOfRemovedElements = intList.RemoveAll(IsMoreThan70);
            Console.WriteLine($"Some {numOfRemovedElements} items has been removed from the list");            

            // Initialization syntax
            List<int> myIntList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };            
        }
    }
}