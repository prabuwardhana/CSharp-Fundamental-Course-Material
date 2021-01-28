using System;

namespace WorkingWithTuples
{
    class Program
    {
        public struct HasilBagi
        {
            public double hasilDouble;
            public int hasilInt;
        }

        static void Main(string[] args)
        {
            double hasilBagiDouble = Pembagian(20, 3, out int hasilBagiInt);
            Console.WriteLine("Hasil Bagi: {0}, Hasil konversi ke integer: {1}", hasilBagiDouble, hasilBagiInt);

            HasilBagi hslBagi = Pembagian(20, 3);
            Console.WriteLine("Hasil Bagi: {0}, Hasil konversi ke integer: {1}", hslBagi.hasilDouble, hslBagi.hasilInt);

            // (double, int) hslBagiTuple = PembagianTuple(20, 3);
            // Console.WriteLine("Hasil Bagi: {0}, Hasil konversi ke integer: {1}", hslBagiTuple.Item1, hslBagiTuple.Item2);

            (double desimal, int bulat) = PembagianTuple(20, 3);
            Console.WriteLine("Hasil Bagi: {0}, Hasil konversi ke integer: {1}", desimal, bulat);
        }

        static double Pembagian(int x, int y, out int hasilInt)
        {
            double hasil;
            if (y != 0)
            {
                hasil = (double)x / y;
                hasilInt = x / y;
            }
            else
            {
                Console.WriteLine("Bilangan pembagi tidak boleh bernilai 0");
                hasil = 0;
                hasilInt = 0;
            }

            return hasil;
        }

        static HasilBagi Pembagian(int x, int y)
        {
            HasilBagi hsl;

            if (y != 0)
            {
                hsl.hasilDouble = (double)x / y;
                hsl.hasilInt = x / y;
            }
            else
            {
                Console.WriteLine("Bilangan pembagi tidak boleh bernilai 0");
                hsl.hasilDouble = 0;
                hsl.hasilInt = 0;
            }

            return hsl;
        }

        // static (double, int) PembagianTuple(int x, int y)
        // {
        //     (double Desimal, int Bulat) hasil;

        //     if (y!=0)
        //     {
        //         hasil.Desimal = (double)x/y;
        //         hasil.Bulat = x/y;
        //     }
        //     else
        //     {
        //         Console.WriteLine("Bilangan pembagi tidak boleh bernilai 0");
        //         hasil.Desimal = 0;
        //         hasil.Bulat = 0;
        //     }

        //     return hasil;
        // }

        static (double, int) PembagianTuple(int x, int y)
        {
            return y != 0 ? ((double)x / y, x / y) : (0, 0);
        }
    }
}
