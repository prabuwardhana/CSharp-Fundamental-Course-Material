using System;

namespace Iteration
{
    class Program
    {
        static void Main(string[] args)
        {
            #region FOR LOOP

            // int i = 0 => Initialize loop.
            // i < 10 => condition.
            // i++ => iterator.

            Console.WriteLine("=> It's a for loop!");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("({0})", i);
            }

            Console.Write("\n");

            for (int i = 9; i >= 0; i--)
            {
                Console.Write("({0})", i);
            }

            Console.Write("\n\n");

            // Nested loop
            Console.WriteLine("=> Iterasi bersarang");
            for (int i = 0; i < 3; i++) // row iteration
            {
                for (int j = 0; j < 3; j++) // column iteration
                {
                    Console.Write("({0}, {1})", i, j);
                }

                Console.Write("\n");
            }

            Console.Write("\n\n");

            // Menentukan jumlah baris dan kolom secara dinamis
            // Dynamically set row and column
            Console.WriteLine("=> Dynamically set row and column");
            int rows, cols;

            Console.Write("Number of rows: ");
            rows = Convert.ToInt32(Console.ReadLine());

            Console.Write("Number of columns: ");
            cols = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("({0}, {1})", i, j);
                }

                Console.Write("\n");
            }

            #endregion

            Console.Write("\n\n");

            #region WHILE LOOP

            Console.WriteLine("=> It's a while loop!");
            int m = 0;
            bool condition = false;

            while (!condition)
            {
                Console.Write("({0})", m);
                m++;
                condition = m >= 10;
            }

            Console.Write("\n\n");

            Console.WriteLine("=> It's a nested while loop!");
            m = 0;
            int n = 0;
            bool condition1 = false;
            bool condition2 = false;

            while (!condition1)
            {
                while (!condition2)
                {
                    Console.Write($"({m}, {n})");
                    n++;
                    condition2 = n > 2;
                }
                m++;
                condition1 = m > 2;

                n = 0;
                condition2 = false;
                Console.Write("\n");
            }

            #endregion

            Console.Write("\n\n");

            #region DO-WHILE LOOP

            Console.WriteLine("=> It's a do-while loop");
            m = 0;
            condition = false;

            do
            {
                Console.Write("({0})", m);
                m++;
                condition = m < 10;
            }
            while (condition);

            Console.Write("\n\n");

            bool doRepeat = false;

            do
            {
                Console.Write("Do you want to repeat? (Y/N)");
                string ans = Console.ReadLine();
                
                if (ans.ToLower() == "y") 
                    doRepeat = true; 
                else
                    doRepeat = false;
            }
            while (doRepeat);
            Console.Write("Thank you...");

            #endregion

            Console.Write("\n\n");

            #region FOREACH LOOP

            Console.WriteLine("=> It's a foreach loop");

            foreach (string arg in args)
            {
                Console.Write("({0})", arg);
            }

            string s = "mahirkoding.id";

            foreach (char c in s)
            {
                Console.Write($"[{c}] ");
            }

            Console.Write("\n\n");

            for (int i = 0; i < s.Length; i++)
            {
                Console.Write($"[{s[i]}] ");
            }

            #endregion

            #region BREAK DAN CONTINUE
            Console.WriteLine("=> Using break and continue");
            for (int i = 0; i < 10; i++)
            {
                // Skip doing everything after this line when i = 2
                if (i == 2) continue;
                Console.Write(i);
                // Stop the loop when i = 5
                if (i == 5) break;
            }
            #endregion

            Console.Write("\n\n");

            #region CODING CHALLENGE
            // Buat bentuk diamond dengan karakter *
            // Hint: Gunakan iterasi for bersarang (nested for loop), gunakan pernyataan if-else bila diperlukan
            // Batasan: Gunakan hanya satu iterasi baris!
            // Pastikan pengguna memberi input bilangan ganjil, apabila input berupa bilangan genap, ulangi permintaan input
            // Hint: Gunakan iterasi do-while

            int input = 0, spaceLoop = 0, printLoop = 0;

            do
            {
                Console.Write("Number of rows (odd number only) : ");
                input = Convert.ToInt32(Console.ReadLine());
            }
            while (input % 2 != 1);

            Console.Write("\n");

            int midPos = (input + 1) / 2;

            for (int i = 0; i < input; i++)
            {
                if (i <= midPos - 1)
                {
                    spaceLoop = midPos - 1 - i;

                    for (int j = 0; j < spaceLoop; j++)
                        Console.Write(" ");

                    printLoop = 2 * i + 1;

                    for (int j = 0; j < printLoop; j++)
                        Console.Write("*");

                    Console.Write("\n");
                }
                else
                {
                    spaceLoop = i + 1 - midPos;

                    for (int j = 0; j < spaceLoop; j++)
                        Console.Write(" ");

                    printLoop = input - (2 * spaceLoop);

                    for (int j = 0; j < printLoop; j++)
                        Console.Write("*");

                    Console.Write("\n");
                }
            }
            #endregion  
        }
    }
}
