using System;
using HandlingException.HelperClass;

namespace HandlingException
{
    public static class Demo3
    {
        public static void Run()
        {
            /*
            MESSAGE: 
            Attempted to divide by zero.

            STACK TRACE:
            at HandlingException.HelperClass.Arithmetic.Division(Int32 numerator, Int32 denominator) in C:\...\Modul01 - Exception Handling\HandlingException\HelperClass\Aritmethic.cs:line 16
            
            RETURN VALUE:
            Hasil: 0
            */
            // ArithmeticA arithmeticA = new ArithmeticA();
            // int resultA = arithmeticA.GetResult(20, 0);

            // Console.WriteLine($"Hasil: {resultA}");

            /*
            MESSAGE: 
            Attempted to divide by zero.

            STACK TRACE:
            at HandlingException.HelperClass.ArithmeticB.Division(Int32 numerator, Int32 denominator) in C:\...\Modul01 - Exception Handling\HandlingException\HelperClass\ArithemticB.cs:line 14
            at HandlingException.HelperClass.ArithmeticB.GetResult(Int32 x, Int32 y) in C:\...\Modul01 - Exception Handling\HandlingException\HelperClass\ArithemticB.cs:line 9
            at HandlingException.Demo3.Run() in C:\...\Modul01 - Exception Handling\HandlingException\Demo3.cs:line 37
            */
            try
            {
                ArithmeticB arithmeticB = new ArithmeticB();
                int resultB = arithmeticB.GetResult(20, 0);

                Console.WriteLine($"Hasil: {resultB}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}