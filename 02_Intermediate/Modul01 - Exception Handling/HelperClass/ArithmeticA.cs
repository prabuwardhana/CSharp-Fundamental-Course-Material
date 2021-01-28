using System;

namespace HandlingException.HelperClass
{
    public class ArithmeticA
    {
        public int GetResult(int x, int y)
        {
            return Division(x, y);
        }

        private int Division(int numerator, int denominator)
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