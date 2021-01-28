using System;

namespace HandlingException
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Triggering an exception                
            // Demo1.Run();
            #endregion

            #region Simple exception handling
            // Demo2.Run();
            #endregion

            #region Better exception handling
            // Demo3.Run();
            #endregion

            #region Configuring the state of an exception
            // Demo4.Run();
            #endregion

            #region Advance exception handling
            // Demo5.Run(args);
            try
            {
                Demo5.Run(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n=== Dari method Main() ===");
                Console.WriteLine("Pesan: {0}", ex.Message);
                Console.WriteLine("Stack: \n{0}", ex.StackTrace);
            }
            #endregion
        }
    }
}
