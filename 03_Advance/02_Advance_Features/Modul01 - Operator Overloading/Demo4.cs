using System;

namespace OperatorOverloading
{
    public class Demo4
    {
        public static void Run()
        {
            Point p1 = new Point(100, 100);
            Point p2 = new Point(40, 40);
            Point p3 = p1;

            Console.WriteLine("p1 == p2: {0}", p1 == p2);
            Console.WriteLine("p1 != p2: {0}", p1 != p2);
            Console.WriteLine("p1 == p3: {0}", p1 == p3);
            Console.WriteLine("p1 != p3: {0}", p1 != p3);
        }
    }
}