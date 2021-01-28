using System;

namespace WorkingWithDelegates
{
    delegate void MulticastDelegate();

    class Demo2
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Multicast Delegate With void Return Type ===");
            // Register MethodOne() with multicastDelegate invocation list
            MulticastDelegate multicastDelegate = MethodOne;
            // Register MethodTwo() with multicastDelegate invocation list
            multicastDelegate += MethodTwo;
            // Invoke multicastDelegate
            multicastDelegate();

            // Remove MethodTwo() from multicastDelegate invocation list
            multicastDelegate -= MethodTwo;
            // Invoke multicastDelegate one more time after removing MethodTwo from delegate invocation list
            multicastDelegate();

            Console.WriteLine("\n=== Multicast Delegate With Return Value ===");
            // Target a static method
            SimpleMathDelegate multiSimpleMath = SimpleMath.Add;

            // Target an instance method
            multiSimpleMath += new SimpleMath().Subtract;

            // Multicast delegate is often used for method with void return type.
            // If we use mlticast delegate for method with a return value,
            // we will get the return value only from the last method in the invocation list
            int result = multiSimpleMath(10, 5);

            Console.WriteLine($"The final value is {result}");
        }

        private static void MethodOne()
        {
            Console.WriteLine("A method of Demo2 class-MethodOne() is executed.");
        }

        private static void MethodTwo()
        {
            Console.WriteLine("A method of Demo2 class-MethodTwo() is executed.");
        }
    }
}