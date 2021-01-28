namespace HandlingException.HelperClass
{
    public class ArithmeticB
    {
        public int GetResult(int x, int y)
        {
            return Division(x, y);
        }

        private int Division(int numerator, int denominator)
        {
            return numerator / denominator;
        }
    }
}