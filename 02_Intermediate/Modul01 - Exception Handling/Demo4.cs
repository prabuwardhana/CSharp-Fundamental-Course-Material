using System;
using HandlingException.HelperClass;

namespace HandlingException
{
    public static class Demo4
    {
        public static void Run()
        {
            try
            {
                ArithmeticB arithmeticB = new ArithmeticB();
                int resultB = arithmeticB.GetResult(20, 0);

                Console.WriteLine($"Result: {resultB}");
            }
            catch (Exception ex)
            {
                // TargetSite property
                /*
                Member name: Int32 Division(Int32, Int32)
                Defined in class: HandlingException.HelperClass.ArithmeticB
                Member type: Method
                */
                Console.WriteLine("Member name: {0}", ex.TargetSite);
                Console.WriteLine("Member type: {0}", ex.TargetSite.MemberType);
                Console.WriteLine("Defined in class: {0}", ex.TargetSite.DeclaringType);

                Console.WriteLine("Message: {0}", ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}