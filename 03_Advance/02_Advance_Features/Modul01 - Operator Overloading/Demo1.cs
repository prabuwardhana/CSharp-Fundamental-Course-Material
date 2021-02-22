using System;

namespace OperatorOverloading
{
    public class Demo1
    {
        public static void Run()
        {
            int a = 10;
            int b = 20;
            int c = a + b;
            Console.WriteLine("{0} + {1} = {2}", a, b, c);

            string s1 = "Hallo ";
            string s2 = "Mahirkoding!";
            string s3 = s1 + s2;
            Console.WriteLine(s3);
        }
    }
}