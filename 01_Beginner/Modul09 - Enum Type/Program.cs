using System;

namespace EnumType
{
    class Program
    {
        #region DECLARING AN ENUM
        // Default declaration
        enum Fruits
        {
            Apple,   // = 0
            Orange,  // = 1
            Banana  // = 2
        }

        // Changing the starting index
        enum Categories
        {
            TShirt = 100,     // The index starts at 100, followed by n + 1
            Trousers,  // = 101
            Jacket,          // = 102
            Bag             // = 103
        }

        // Assigning index to element doesn't to be in sequence number
        enum ErrNum
        {
            InputError = 202,
            VerificationError = 101,
            OperationError = 303
        }
        #endregion

        #region DEFINING THE UNDERLYING TYPE OF AN ENUM
        // Secara default, tipe yang mendasari sebuah enum adalah tipe int
        // kita bisa menggantinya dengan tipe data numerik yang lain seperti byte, short, atau long
        enum anEnum : byte
        {
            element1 = 10,
            element2 = 1,
            element3 = 100,
            element4 = 9
            // elemen berikut ini menghasilkan eror
            // angka 999 tidak dapat ditampung oleh byte
            // elemen4 = 999
        }
        #endregion

        static void Main(string[] args)
        {
            #region MOTIVASI MENGGUNAKAN TIPE ENUM
            Console.Write("Choose your favorite fruit [1: Apple][2: Orange][3: Banana]: ");
            int choice = Int32.Parse(Console.ReadLine());

            // switch (choice)
            // {
            //     case 1:
            //         Console.WriteLine("You choosed apple");
            //         break;
            //     case 2:
            //         Console.WriteLine("You choosed orange");
            //         break;
            //     case 3:
            //         Console.WriteLine("You choosed banana");
            //         break;
            //     default:
            //         Console.WriteLine("You have not choosen anything");
            //         break;
            // }

            // tipe enum merupakan tipe data kustom
            // tipe data yang kita buat sesuai kebutuhan
            // bisa digunakan sebagai tipe data dari sebuah variabel yang dideklarasikan
            Fruits fruit = (Fruits)choice;

            //　Menggunakan pernyataan switch dengan tipe enum
            switch (fruit)
            {
                // Menggunakan tipe enum menghindarkan kita pada penggunaan angka ajaib (magic number)
                case Fruits.Apple:
                    Console.WriteLine("You choosed apple");
                    break;
                case Fruits.Orange:
                    Console.WriteLine("You choosed orange");
                    break;
                case Fruits.Banana:
                    Console.WriteLine("You choosed banana");
                    break;
                default:
                    Console.WriteLine("Your choice is not in the list");
                    break;
            }
            #endregion

            #region MENDEKLARASIKAN VARIABLE DENGAN TIPE ENUM
            Categories item = Categories.TShirt;
            // Categories item = Categories.Sweater; // Eror! Sweater belum didefinisikan di dalam daftar kategoriBarang
            // Categories item = Kaos; // Eror! Kaos harus diberi konteks sebagai KategoriBarang
            ShowPrice(item);
            #endregion

            Console.ReadLine();
        }

        static void ShowPrice(Categories item)
        {
            switch (item)
            {
                case Categories.Trousers:
                    Console.WriteLine("Trousers: Rp. 200.000,-");
                    break;
                case Categories.Jacket:
                    Console.WriteLine("Jacket: Rp. 350.000,-");
                    break;
                case Categories.TShirt:
                    Console.WriteLine("T-Shirt: Rp. 100.000,-");
                    break;
                case Categories.Bag:
                    Console.WriteLine("Bag: Rp. 250.000,-");
                    break;
                default:
                    Console.WriteLine("No data to show");
                    break;
            }
        }
    }
}
