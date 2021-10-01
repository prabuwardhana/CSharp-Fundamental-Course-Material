using System;

namespace WorkingWithTuples
{
    class Program
    {
        public struct DivResult
        {
            public double DoubleResult;
            public int IntResult;
        }

        static void Main(string[] args)
        {
            double DivResultDouble = Division(20, 3, out int DivResultInt);
            Console.WriteLine("Division result: {0}, Result of to integer conversion: {1}", DivResultDouble, DivResultInt);

            DivResult divResult = Division(20, 3);
            Console.WriteLine("Division result: {0}, Result of to integer conversion: {1}", divResult.DoubleResult, divResult.IntResult);

            (double, int) divResultTuple = DivisionReturnsTupleVer2(20, 3);
            Console.WriteLine("Division result: {0}, Result of to integer conversion: {1}", divResultTuple.Item1, divResultTuple.Item2);

            (double resultDouble, int resultInt) = DivisionReturnsTupleVer2(20, 3);
            Console.WriteLine("Hasil Bagi: {0}, Hasil konversi ke integer: {1}", resultDouble, resultInt);
        }

        static double Division(int x, int y, out int hasilInt)
        {
            double hasil;
            if (y != 0)
            {
                hasil = (double)x / y;
                hasilInt = x / y;
            }
            else
            {
                Console.WriteLine("Denominator cannot be zero");
                hasil = 0;
                hasilInt = 0;
            }

            return hasil;
        }

        static DivResult Division(int x, int y)
        {
            DivResult hsl;

            if (y != 0)
            {
                hsl.DoubleResult = (double)x / y;
                hsl.IntResult = x / y;
            }
            else
            {
                Console.WriteLine("Denominator cannot be zero");
                hsl.DoubleResult = 0;
                hsl.IntResult = 0;
            }

            return hsl;
        }

        static (double, int) DivisionReturnsTupleVer1(int x, int y)
        {
            (double Desimal, int Bulat) hasil;

            if (y!=0)
            {
                hasil.Desimal = (double)x/y;
                hasil.Bulat = x/y;
            }
            else
            {
                Console.WriteLine("Bilangan pembagi tidak boleh bernilai 0");
                hasil.Desimal = 0;
                hasil.Bulat = 0;
            }

            return hasil;
        }

        static (double, int) DivisionReturnsTupleVer2(int x, int y)
        {
            return y != 0 ? ((double)x / y, x / y) : (0, 0);
        }
    }
}
