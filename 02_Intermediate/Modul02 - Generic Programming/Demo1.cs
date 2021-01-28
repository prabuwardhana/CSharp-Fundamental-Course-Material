using System;

namespace GenericProgramming
{
    public class Demo1
    {
        public static void Run()
        {
            Console.WriteLine("=== Non-generic Method ===");
            int x = 5, y = 10;
            double a = 25.5, b = 38.7;
            string s1 = "Hi!", s2 = "Hello!";

            // Calling non-generic method means we need to provide overload for each type
            Swap(ref x,ref y);
            Swap(ref a, ref b);
            Swap(ref s1, ref s2);

            Console.WriteLine("\n=== Generic Method ===");
            // We can now use the same method with different types
            Swap<int>(ref x,ref y);
            Swap<double>(ref a, ref b);
            Swap<string>(ref s1, ref s2);
        }

        // Swap two integers
        static void Swap(ref int a, ref int b)
        {
            Console.WriteLine("=>Swap two integer value");
            Console.WriteLine("Before swap: {0}, {1}", a, b);
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("After swap: {0}, {1}\n", a, b);
        }

        // swap two double
        static void Swap(ref double a, ref double b)
        {
            Console.WriteLine("=>Swap two double value");
            Console.WriteLine("Before swap: {0}, {1}", a, b);
            double temp = a;
            a = b;
            b = temp;
            Console.WriteLine("After swap: {0}, {1}\n", a, b);
        }

        // swap two string
        static void Swap(ref string a, ref string b)
        {
            Console.WriteLine("=>Swap two string value");
            Console.WriteLine("Before swap: {0}, {1}", a, b);
            string temp = a;
            a = b;
            b = temp;
            Console.WriteLine("After swap: {0}, {1}\n", a, b);
        }

        // <T>: Type parameter
        // This method will swap any two items. as specified by the type parameter <T>.
        static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("=>Swap two {0} value", typeof(T));
            Console.WriteLine("Before swap: {0}, {1}", a, b);
            T temp = a;
            a = b;
            b = temp;
            Console.WriteLine("After swap: {0}, {1}\n", a, b);
        }
    }
}