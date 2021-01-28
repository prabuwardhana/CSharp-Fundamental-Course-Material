using System;

namespace HandlingException
{
    public class Demo2
    {
        public static void Run()
        {
            /*
            ex.Message: Attempted to divide by zero.
            ex.StackTrace: at HandlingException.Demo2.Division(Int32 numerator, Int32 denominator) in C:\...\Modul01 - Exception Handling\HandlingException\Demo2.cs:line 23
            Return value: Hasil: 0
            */
            int result = Division(20, 0);

            Console.WriteLine($"Hasil: {result}");
        }

        private static int Division(int numerator, int denominator)
        {
            try
            {
                return numerator / denominator;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            return 0;
        }
    }
}