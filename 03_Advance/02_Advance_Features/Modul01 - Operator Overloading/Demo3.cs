using System;

namespace OperatorOverloading
{
    public class Demo3
    {
        public static void Run()
        {
            Point p1 = new Point(1, 1);
            Console.WriteLine("++p1: {0}", ++p1);
            Console.WriteLine("--p1: {0}", --p1);

            Point p2 = new Point(20, 20);
            Console.WriteLine("p2++: {0}", p2++);
            Console.WriteLine("p2--: {0}", p2--);
        }
    }
}