using System;

namespace ArrayType
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 10;
            int num2 = 20;
            int num3 = 30;
            int num4 = 40;
            int num5 = 50;

            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
            Console.WriteLine(num4);
            Console.WriteLine(num5);

            #region ARRAY DECLARATION AND INITIALIZATION
            // // Array declaration
            // int[] anArray;

            // // Array initialization
            // // The number in the square bracket is the size of the array
            // anArray = new int[4];

            // // Declaring and initializing an Array in single line.
            // int[] anArray = new int[4];

            // // Initializing an array like below can only be done at the same time when declaring the variable.
            // // Declaring and populating anArray with the 5, 8, 12, and 96.
            // int[] anArray = new int[4] {5, 8, 12, 96};

            // // This time, we acctually don't need to specify the size of the array
            // int[] anArray = new int[] {5, 8, 12, 96};

            // We can simplify the code even further
            int[] anArray = { 5, 8, 12, 96 };

            foreach (int i in anArray)
            {
                Console.WriteLine($"{i}");
            }
            #endregion

            #region ACCESSING ARRAY ELEMENTS            
            // The index of array starts from 0
            // 0 => 5, 1 => 8, 2 => 12, 3 => 96
            int[] intArr = { 5, 8, 12, 96 };

            Console.WriteLine($"Nilai dari elemen-elemen intArr[]: {intArr[0]}, {intArr[1]}, {intArr[2]}, {intArr[3]}");

            // Replace the element at index 0
            intArr[0] = 153;
            // Replace the element at index 3
            intArr[3] = 67;
            Console.WriteLine($"Nilai elemen intArr[] setelah diganti: {intArr[0]}, {intArr[1]}, {intArr[2]}, {intArr[3]}");

            // // Let's try to create a new element at index 4.
            // // No, it won't work! The length of Array in C# can't be changed dynamically
            // // Once the length has been decided, we're not able to grow and shrink its size.
            // // Uncomment below code, and you'll get this nasty error -> runtime eror! IndexOutOfRangeException
            // intArr[4] = 89;
            // Console.WriteLine(intArr[4]);
            #endregion

            #region ITERATION ON ARRAY ELEMENTS
            // Remember our previous array declaration
            // int[] intArr = { 5, 8, 12, 96 };

            Console.WriteLine($"Length of intArr = {intArr.Length}");
            for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine($"Element at {i} = {intArr[i]}");
            }

            for (int i = 0; i < intArr.Length; i++)
            {
                Console.WriteLine($"Element at {i} = {intArr[i]}");
            }

            foreach (int value in intArr)
            {
                Console.WriteLine($"Value = {value}");
            }
            #endregion

            #region ARRAY OF STRING TYPE
            string[] strArray = { "Slamet", "Budi", "Ucok", "Ketut" };

            foreach (string value in strArray)
            {
                Console.WriteLine(value);
            }
            #endregion

            #region MULTIDIMENSIONAL ARRAY
            // // int[rows, cols]
            // // int[,] twoDimension = new int[3, 3];
            // twoDimension[0, 0] = 1;
            // twoDimension[0, 1] = 2;
            // twoDimension[0, 2] = 3;
            // twoDimension[1, 0] = 4;
            // twoDimension[1, 1] = 5;
            // twoDimension[1, 2] = 6;
            // twoDimension[2, 0] = 7;
            // twoDimension[2, 1] = 8;
            // twoDimension[2, 2] = 9;

            int[,] twoDimension =
            {
                {1, 2, 3}, // row 1
                {4, 5, 6}, // row 2
                {7, 8, 9} // row 3
            };

            for (int i = 0; i < twoDimension.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimension.GetLength(1); j++)
                {
                    Console.WriteLine($"Row = {i}, Column = {j}, Value = {twoDimension[i, j]}");
                }
            }
            #endregion

            #region JAGGED ARRAY
            // Only need to specify the number of rows, left the columns number empty.
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[2] { 1, 2 };
            jaggedArray[1] = new int[6] { 3, 4, 5, 6, 7, 8 };
            jaggedArray[2] = new int[3] { 9, 10, 11 };

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"{jaggedArray[i][j]} ");
                }
                Console.WriteLine();
            }
            #endregion

            #region FUNCTIONS ON ARRAY
            string[] nameList = { "Donald", "Daisy", "Mickey", "Minnie", "Guffy" };
            Console.WriteLine("=> List of name: ");
            for (int i = 0; i < nameList.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {nameList[i]}");
            }
            Console.WriteLine();

            System.Array.Reverse(nameList);
            Console.WriteLine("=> Reversed list of name: ");
            for (int i = 0; i < nameList.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {nameList[i]}");
            }
            Console.WriteLine();

            System.Array.Sort(nameList);
            Console.WriteLine("=> Sorted list of name : ");
            for (int i = 0; i < nameList.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {nameList[i]}");
            }
            Console.WriteLine();

            System.Array.Clear(nameList, 1, 2);
            Console.WriteLine("=> Cleared list of name : ");
            for (int i = 0; i < nameList.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {nameList[i]}");
            }
            Console.WriteLine();
            #endregion          

            Console.ReadLine();
        }
    }
}
