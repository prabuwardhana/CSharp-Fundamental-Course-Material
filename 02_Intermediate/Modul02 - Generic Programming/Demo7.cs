using System;

namespace GenericProgramming
{
    class MyClass<T,U>
    {
        public void MyMethod(T param1, U param2)
        {
            Console.WriteLine("Inside MyMethod(T param1, U param2)");
        }

        public void MyMethod(U param1, T param2)
        {
            Console.WriteLine("Inside MyMethod(U param1, T param2)");
        }
    }

    public class Demo7
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Overloading Generic Method ===");
            // Consider this overload. This runs without problem.
            MyMethod(10, 10.5);
            MyMethod(10.5, 10);

            // OK, this seems obvious.
            MyClass<int, double> object1 = new MyClass<int, double>();
            // T = int; U = double
            object1.MyMethod(1, 2.3);

            MyClass<double, int> object2 = new MyClass<double, int>();
            // T = double; U = int
            // The type difference is not considered on generic types; instead, 
            // it depends on the type argument that you substitute for a type parameter.
            // Output: Inside MyMethod(U param1, T param2)
            object2.MyMethod(1, 2.3);
            // Output: Inside MyMethod(T param1, U param2)
            object2.MyMethod(2.3, 1);

            MyClass<int, int> object3 = new MyClass<int, int>();
            // // ERROR!
            // // The call is ambiguous between the following methods or properties:
            // // 'MyClass<T, U>.MyMethod(T, U)' and 'MyClass<T, U>.MyMethod(U, T)'
            // object3.MyMethod(2, 4);
        }

        public static void MyMethod(int a, double b) { /* some code */ }
        public static void MyMethod(double b, int a) { /* some code */ }
    }
}