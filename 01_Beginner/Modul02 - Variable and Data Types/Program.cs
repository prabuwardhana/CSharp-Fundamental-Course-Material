using System;

namespace VariableDataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uncomment these codes by selecting all the commented code, then press ctrl+k+u.
            // Comment it back by selecting the code you want to comment, then press ctrl+k+s.
            #region VARIABLE DECLARATION AND INITIALIZATION
            // // Variable declaration [data_type] [variable_name]
            // int varInt;
            // string varStr;

            // // Eror! Use of unassigned variable
            // Console.WriteLine("Value of varInt: {0}",varInt);
            // Console.WriteLine("Value of varStr: {0}",varStr);

            // // ===================================================
            // // Declare and initialize variable in a single line
            // // ===================================================

            // int varInt = 0;

            // Console.WriteLine("Value of varInt: {0}",varInt);

            // // ===================================================
            // // Declare and initialize variable in separate line
            // // ===================================================

            // // Variable declaration
            // string varStr;
            
            // // Variable initialization
            // varStr = "";

            // Console.WriteLine("Value of varStr: {0}",varStr);

            // // ===================================================
            // // Declare and initialize variables with the same type in a single line
            // // ===================================================

            // bool b1 = true, b2 = false, b3 = b1;

            // Console.WriteLine("Nilai variabel b1: {0}", b1);
            // Console.WriteLine("Nilai variabel b2: {0}", b2);
            // Console.WriteLine("Nilai variabel b3: {0}", b3);

            // // ===================================================
            // // Declare a variable using .NET built in data type
            // // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/built-in-types-table
            // // ===================================================

            // System.Int32 varInt = 0;
            // System.String varStr = "";
            // System.Boolean b1 = true, b2 = false, b3 = b1;

            // Console.WriteLine("Value of varInt: {0}", varInt);
            // Console.WriteLine("Value of varStr: {0}", varStr);
            // Console.WriteLine("Value of b1: {0}", b1);
            // Console.WriteLine("Value of b2: {0}", b2);
            // Console.WriteLine("Value of b3: {0}", b3);
            #endregion

            #region DEFAULT LITERAL
            // int varInt = default;
            // double varDouble = default;
            // string varStr = default;
            // bool varBool = default;

            // Console.WriteLine("Nilai variabel varInt: {0}", varInt);
            // Console.WriteLine("Nilai variabel varDouble: {0}", varDouble);
            // Console.WriteLine("Nilai variabel varStr: {0}", varStr);            
            // Console.WriteLine("Nilai variabel varBool: {0}", varBool);
            #endregion

            #region VALUE TYPE
            #region Integer Number
            sbyte varSbyte;     // 8-bit signed integer, -128 (-2^7) ~ 127 (2^7 - 1)
            varSbyte = -128;
            Console.WriteLine("Value of varSbyte: {0}", varSbyte);
            varSbyte = 127;
            Console.WriteLine("Value of varSbyte: {0}", varSbyte);

            // // Below code will show an error.
            // // The value assigned to the variable is out of sbyte data type range.
            // varSbyte = -129;
            // varSbyte = 128;

            short varShort;     // 16-bit signed integer, -32,768 (-2^15) ~ 32,767 (2^15 - 1)
            varShort = -32768;
            Console.WriteLine("Value of varShort: {0}", varShort);
            varShort = 32767;
            Console.WriteLine("Value of varShort: {0}", varShort);

            int varInt;         // 32-bit signed integer, -2,147,483,648 (-2^31) ~ 2,147,483,647 (2^31 - 1)
            varInt = -2147483648;
            Console.WriteLine("Value of varInt: {0}", varInt);
            varInt = 2147483647;
            Console.WriteLine("Value of varInt: {0}", varInt);

            long varLong;       // 64-bit signed integer, –9,223,372,036,854,775,808 (-2^63) ~ 9,223,372,036,854,775,807 (2^63 - 1)
            // Using digits separator
            varLong = -9_223_372_036_854_775_808;
            Console.WriteLine("Value of varLong: {0}", varLong);
            // Using digits separator
            varLong = 9_223_372_036_854_775_807;
            Console.WriteLine("Value of varLong: {0}", varLong);

            byte varByte;       // 8-bit unsigned integer, 0 ~ 255 (2^8 - 1)
            varByte = 0;
            Console.WriteLine("Value of varByte: {0}", varByte);
            varByte = 255;
            Console.WriteLine("Value of varByte: {0}", varByte);

            ushort varUshort;   // 16-bit unsigned integer, 0 ~ 65,535 (2^16 - 1)
            varUshort = 0;
            Console.WriteLine("Value of varUshort: {0}", varUshort);
            varUshort = 65535;
            Console.WriteLine("Value of varUshort: {0}", varUshort);

            uint varUint;       // 32-bit unsigned integer, 0 ~ 4,294,967,295 (2^32 - 1)
            varUint = 0;
            Console.WriteLine("Value of varUint: {0}", varUint);
            varUint = 4294967295;
            Console.WriteLine("Value of varUint: {0}", varUint);

            ulong varUlong;     // 64-bit unsigned integer, 0 ~ 18,446,744,073,709,551,615 (2^64 - 1)
            varUlong = 0;
            Console.WriteLine("Value of varUlong: {0}", varUlong);
            varUlong = 18446744073709551615;
            Console.WriteLine("Value of varUlong: {0}", varUlong);

            // // By default, 1234 is considered as an integer.
            // uint ui = 1234U;
            // long l = 1234L;
            // ulong ul = 1234UL;

            // // Eror! Even the number 1234 is still in the range of integer data type.
            // // By appending the character U behind the number, the number will be considerd as an unsigned integer.
            // int i = 1234U;
            // int i = 1234L;
            // int i = 1234UL;
            #endregion

            #region Floating Number          
            float varFloat;     // 32-bit, presisi 7 digit
            varFloat = 17.5f;

            // // Below code will generate an error.
            // // By default, floating number will be treated as double.
            // varFloat = 17.5;
            Console.WriteLine("Value of varFloat: {0}", varFloat);

            double varDouble;   // 64-bit, presisi 15 digit
            // // By default, floating number will be treated as double.
            varDouble = 17.5;
            // // Or you can explicitly state that the number is a double
            // // by appending the character "d" behind the number
            // varDouble = 17.5d;
            Console.WriteLine("Value of varDouble: {0}", varDouble);

            decimal varDecimal;
            varDecimal = 17.5M; // 128-bit, presisi 28 digit
            
            // // Below code will generate an error.
            // // By default, floating number will be treated as double.
            // varDecimal = 17.5;
            Console.WriteLine("Value of varDecimal: {0}", varDecimal);
            #endregion
            #endregion

            #region REFERENCE TYPE
            object objInt = 25;
            Console.WriteLine("Value of objInt: {0}", objInt);
            
            object objDouble = 15.8;
            Console.WriteLine("Value of objDouble: {0}", objDouble);
            
            object objStr = "teks";
            Console.WriteLine("Value of objStr: {0}", objStr);

            string varString = "hello!";
            Console.WriteLine(varString);
            #endregion
        }
    }
}
