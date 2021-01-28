using System;

namespace GenericProgramming
{
    public class Demo2
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Type Inference In Generic Method Call ===");
            bool b1 = true, b2 = false;
            Swap(ref b1, ref b2);

            int a1 = 10, a2 = 20;
            Swap(ref a1, ref a2);

            // // Compiler error! No params? Must supply placeholder (type parameter)!
            // DisplayBaseClass();
            DisplayBaseClass<int>();
            DisplayBaseClass<string>();
        }        

        static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("=>Swap two {0} value", typeof(T));
            Console.WriteLine("Before swap: {0}, {1}", a, b);
            T temp = a;
            a = b;
            b = temp;
            Console.WriteLine("After swap: {0}, {1}\n", a, b);
        }

        static void DisplayBaseClass<T>()
        {
            // Examine the base type of type T
            Console.WriteLine("Base class of {0} is: {1}.", typeof(T), typeof(T).BaseType);
        }
    }
}