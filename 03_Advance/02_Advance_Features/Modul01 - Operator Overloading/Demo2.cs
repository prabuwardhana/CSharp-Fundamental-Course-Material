using System;

namespace OperatorOverloading
{
    public class Demo2
    {
        public static void Run()
        {
            Point p1 = new Point(100, 100);
            Point p2 = new Point(40, 40);
            Console.WriteLine("p1 = {0}", p1);
            Console.WriteLine("p2 = {0}", p2);

            // p1 + p2
            Console.WriteLine("\np1 + p2 = {0}", p1 + p2);
            // p1 - p2
            Console.WriteLine("p1 - p2 = {0}", p1 - p2);

            // using shorthand
            Console.WriteLine("\np1 += p2: {0}", p1 += p2);
            Console.WriteLine("p1 -= p2: {0}", p1 -= p2);
        }
    }
}