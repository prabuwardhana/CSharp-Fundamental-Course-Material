using System;

namespace CustomIterator
{
    public class Demo1
    {
        public static void Run()
        {
            int[] intArray = { 10, 20, 30, 40, 50 };

            foreach(int i in intArray)
            {
                Console.WriteLine(i);
            }

            /********************************************************************************************** 
            # Doing iteration on an Array is possible because Array type implemements GetEnumerator() method
            # defined in IEnumerable interface.
            # https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable.getenumerator?view=netframework-4.8
            # Not exclusive to an array, every type that implements GetEnumerator() method can be iterated using foreach loop
            **********************************************************************************************/
            intArray.GetEnumerator();     
        }
    }
}