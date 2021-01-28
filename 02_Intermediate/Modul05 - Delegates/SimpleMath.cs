namespace WorkingWithDelegates
{
    // Declaring a delegate type.
    // This delegate can point to any method,
    // taking two integer, and returning an integer.
    public delegate int SimpleMathDelegate(int x, int y);

    // This class contains methods ArithmeticOpDelegate will point to.
    public class SimpleMath
    {
        // Remove this method to proof that overload does not work with delegate
        public static int Add(int x, int y) => x + y;
        // Overload Add() method
        public static double Add(double x, double y) => x + y;
        public int Subtract(int x, int y) => x - y;
        public int Multiply(int x, int y) => x * y;
    }
}