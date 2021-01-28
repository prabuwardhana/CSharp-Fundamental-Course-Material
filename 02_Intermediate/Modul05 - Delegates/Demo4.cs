using System;

namespace WorkingWithDelegates
{
    // Declaring a generic delegate with a return value.
    public delegate T ReturnGenericDelegate<T>(T args1, T args2);
    // Declaring a generic delegate with void return type.
    public delegate void VoidGenericDelegate<T>(T arg);

    public class Demo4
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Generic Delegate ===");
            ReturnGenericDelegate<int> genAdd1 = new ReturnGenericDelegate<int>(SimpleMath.Add);
            Console.WriteLine("genAdd1(int): 10 + 20 = {0}", genAdd1(10, 20));

            ReturnGenericDelegate<double> genAdd2 = new ReturnGenericDelegate<double>(SimpleMath.Add);
            Console.WriteLine("genAdd2(double): 8.5 + 9.5 = {0}", genAdd2(8.5, 9.5));

            VoidGenericDelegate<string> strTarget = new VoidGenericDelegate<string>(StringTarget);
            strTarget("hello from mahirkoding.id!");

            VoidGenericDelegate<int> intTarget = new VoidGenericDelegate<int>(IntTarget);
            intTarget(9);

            Console.WriteLine("\n=== Func<> ===");
            // Func<param1type, param2type, returntype>
            Func<int, int, int> funcAdd1 = new Func<int, int, int>(SimpleMath.Add);            
            Console.WriteLine("funcAdd1(int): 10 + 20 = {0}", funcAdd1(10, 20));

            Func<double, double, double> funcAdd2 = SimpleMath.Add;
            Console.WriteLine("funcAdd2(double): 8.5 + 9.5 = {0}", funcAdd2(8.5, 9.5));

            Console.WriteLine("\n=== Action<> ===");
            // Action<paramtype>
            Action<string> strActionTarget = new Action<string>(StringTarget);
            strTarget("hello from mahirkoding.id!");

            Action<int> intActionTarget = IntTarget;
            intTarget(9);            

            Console.WriteLine("\n=== Predicate<> ===");
            Predicate<int> isGreater = IsGreaterThan100;
            Console.WriteLine("101 is greater than 100? {0}", isGreater(101));
            Console.WriteLine("99 is greater than 100? {0}", isGreater(99));

            Console.WriteLine("\n=== Array of generic delegates ===");
            Func<int, int, int>[] op = { Add, Subtract, Multiply };

            int operation = 1;
            Console.WriteLine("result: {0}", op[operation - 1](20, 10));
            operation = 2;
            Console.WriteLine("result: {0}", op[operation - 1](20, 10));
            operation = 3;
            Console.WriteLine("result: {0}", op[operation - 1](20, 10));
        }

        private static void StringTarget(string arg) => Console.WriteLine("uppercase arg: {0}", arg.ToUpper());
        private static void IntTarget(int arg) => Console.WriteLine("++arg: {0}", ++arg);
        private static bool IsGreaterThan100(int myInt) => myInt > 100 ? true : false;

        private static int Add(int x, int y) => x + y;
        private static int Subtract(int x, int y) => x - y;
        private static int Multiply(int x, int y) => x * y;
    }
}