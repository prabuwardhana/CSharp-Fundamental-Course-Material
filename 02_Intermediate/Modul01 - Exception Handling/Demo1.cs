using System;

namespace HandlingException
{
    public class Demo1
    {
        public static void Run()
        {
            /*
            Unhandled exception. System.DivideByZeroException: Attempted to divide by zero.
            at HandlingException.Demo1.Division(Int32 numerator, Int32 denominator) in C:\...\Modul01 - Exception Handling\HandlingException\Demo1.cs:line 22
            at HandlingException.Demo1.Run() in C:\...\Modul01 - Exception Handling\HandlingException\Demo1.cs:line 15
            at HandlingException.Program.Main(String[] args) in C:\...\Modul01 - Exception Handling\HandlingException\Program.cs:line 11
            */
            int result = Division(20, 0);

            Console.WriteLine($"Hasil: {result}");
        }

        private static int Division(int numerator, int denominator)
        {
            return numerator / denominator;
        }
    }
}