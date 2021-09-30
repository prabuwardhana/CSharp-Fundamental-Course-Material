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
            Console.WriteLine("=> Register MethodOne() with multicastDelegate invocation list");
            MulticastDelegate multicastDelegate = MethodOne;
            // Register MethodTwo() with multicastDelegate invocation list
            Console.WriteLine("=> Register MethodTwo() with multicastDelegate invocation list");
            multicastDelegate += MethodTwo;
            // Invoke multicastDelegate
            multicastDelegate();

            // Remove MethodTwo() from multicastDelegate invocation list
            Console.WriteLine("=> Remove MethodTwo() from multicastDelegate invocation list");
            multicastDelegate -= MethodTwo;
            // Invoke multicastDelegate one more time after removing MethodTwo from delegate invocation list
            multicastDelegate();

            /** OUTPUT **/
            /************************************
            # === Multicast Delegate With void Return Type ===
            # => Register MethodOne() with multicastDelegate invocation list
            # => Register MethodTwo() with multicastDelegate invocation list
            # A method of Demo2 class-MethodOne() is executed.
            # A method of Demo2 class-MethodTwo() is executed.
            # => Remove MethodTwo() from multicastDelegate invocation list
            # A method of Demo2 class-MethodOne() is executed.
            ************************************/

            Console.WriteLine("\n=== Multicast Delegate With Return Value ===");
            // Target a static method
            Console.WriteLine("=> Register SimpleMath.Add() with multiSimpleMath invocation list");
            SimpleMathDelegate multiSimpleMath = SimpleMath.Add;

            // Target an instance method
            Console.WriteLine("=> Register SimpleMath.Subtract() with multiSimpleMath invocation list");
            multiSimpleMath += new SimpleMath().Subtract;

            /************************************
            # Multicast delegate is often used for method with void return type.
            # If we use multicast delegate for method with a return value,
            # we will get the return value only from the last method in the invocation list
            ************************************/
            int result = multiSimpleMath(10, 5);

            Console.WriteLine($"The final value for multiSimpleMath(10, 5) is {result}");

            /** OUTPUT **/
            /************************************
            # === Multicast Delegate With void Return Type ===
            # => Register SimpleMath.Add() with multiSimpleMath invocation list
            # => Register SimpleMath.Subtract() with multiSimpleMath invocation list
            # The final value for multiSimpleMath(10, 5) is 5
            ************************************/
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