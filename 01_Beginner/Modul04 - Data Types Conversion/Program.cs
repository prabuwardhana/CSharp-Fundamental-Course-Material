using System;

namespace DataTypeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            short num1, num2; // max value for short = 32,767
            int num3, num4; // max value for int = 2,147,483,647

            #region IMPLICIT CONVERSION
            /* Widening operation */
            num1 = 10;
            num2 = 15;
            int sum = num1 + num2;
            Console.WriteLine("{0} + {1} = {2}", num1, num2, sum);

            num3 = 6000;
            num4 = 350000;
            // the result for this multiplication is stored to variable that has wider range of value
            long product = num3 * num4; // max value for long = 9,223,372,036,854,775,807
            Console.WriteLine("{0} + {1} = {2}", num3, num4, product);

            /* Narrowing operation */
            // // Compile error!
            // // Cannot store the value to a variable that has a narrower range of value
            //short sumShort = num1 + num2;
            
            byte varByte = 0; // max value for byte = 255
            // Initialize varInt with 200.
            // Let's see what would happen!
            int varInt = 200;
            // // Compile error!
            // // Cannot convert implicitly.
            // // int has wider range than byte, even varInt has only 200 as its value. Still, it won't work!
            // // Try to uncomment this line of code and you will get that ugly red squiggle.
            // varByte = varInt;

            /* 
                Note: Narrowing operation on implicit type conversion always resulting an error!
            */
            #endregion

            #region EXPLICIT CONVERSION
            // casting
            short anotherSumShort = 0;

            // if the sum of num1 and num2 is still in the range of short, this will work.
            anotherSumShort = (short)(num1 + num2);
            // if the value of varInt is still in the range of short, this will work.
            // Try to change varInt value to a bigger number, let say 260, then you will get a nasty error.
            varByte = (byte)varInt;
            Console.WriteLine("anotherSumShort = {0}; varByte = {1}", anotherSumShort, varByte);

            // Using the built in static class Convert from System namespace
            // .NET type for short is System.Int16
            // Again, the same condition as above still applies.
            anotherSumShort = Convert.ToInt16(num1 + num2);
            varByte = Convert.ToByte(varInt);
            Console.WriteLine("anotherSumShort = {0}; varByte = {1}", anotherSumShort, varByte);
            #endregion

            #region CHECKED KEYWORD
            num1 = 30000;
            num2 = 30000;
            // + operator converts the operands to int implicitly
            // Remember that both num1 and num2 were declared as short.
            // Due to that implicit conversion, you need to convert the sum result back to short.
            anotherSumShort = (short)(num1 + num2);
            // BUT.....
            // Can you expect the output? is it 60000?
            // No, it is NOT! You will get -5536 instead of 60000!
            Console.WriteLine("jumlahShort = {0}", anotherSumShort);

            // This phenomenon is called Signed Overflow!
            // Check the explanation bellow

            /*
             * Signed overflow: 30000 + 30000 = 60000, short is a signed 16-bit, with max value of 32767, and range -32767~32767
             * 
             * |15|14|13|12| |11|10|9 |8 | |7 |6 |5 |4 | |3 |2 |1 |0 | => bit position
             * -------------------------------------------------------
             * |1 |1 |1 |0 | |1 |0 |1 |0 | |0 |1 |1 |0 | |0 |0 |0 |0 | => bit value representing 60000 
             * -------------------------------------------------------
             * Left most bit is the signed bit (1=represents negative bit, 0=represents positive bit)
             * All other bits are called the magnitude bit (represents value)
             * Let's do the math!
             * -2^15 + 2^14 + 2^13 + 2^11 + 2^9 + 2^6 + 2^5 = -32768 + 16384 + 8192 + 2048 + 512 + 64 + 32 = -5536
             */

            // Check this other example!

            byte b1 = 100;
            byte b2 = 250;
            byte jml = 0;
            
            jml = (byte)(b1 + b2);
            // What do you expect will be the output?
            // 350? Wrong answer! You will get 94 instead of 350. But how come?
            Console.WriteLine("jml = {0}", jml);

            // This phenomenon is called Unsigned Overflow!
            // Check the explanation bellow

            /*
            * Unsigned overflow: 100 + 250 = 350, short is an unsigned 8-bit, with max value of 255, and range 0~255
            * 
            * |11|10|9 |8 | |7 |6 |5 |4 | |3 |2 |1 |0 | => posisi bit
            * -------------------------------------------------------
            * |0 |0 |0 |1 | |0 |1 |0 |1 | |1 |1 |1 |0 | => nilai bit
            * -------------------------------------------------------
            * Because short is an unsigned 8-bit, bit at index 8 to 11 is out of short's range. It will be ignored when stored in a short variable.
            * only value of bit 0 to bit 7 will be stored.
            * Let's do another math!
            * 2^6 + 2^4 + 2^3 + 2^2 + 2^1 = 64 + 16 + 8 + 4 + 2 = 94
            */

            // By using checked keyword, the compiler will check if the arithmetic operation resulted in an overflow or not
            // if it is, it will throw an OverflowException
            try
            {
                jml = checked((byte)(b1 + b2));
                Console.WriteLine("jml = {0}", jml);
                anotherSumShort = checked((short)(num1 + num2));
                Console.WriteLine("jumlahShort = {0}", anotherSumShort);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message); // arithmetic operation resulted in an overflow
            }
            #endregion

            #region PARSING
            // Converting another value to a string is called parsing
            /* Parse() */
            // Parse a string to a boolean value
            bool b = bool.Parse("true");
            Console.WriteLine("Value of b = {0}", b);
            // Parse a string to an int value
            int i = int.Parse("2019");
            Console.WriteLine("Value of i = {0}", i);
            // Parse a string to a double value
            double d = double.Parse("29.56");
            Console.WriteLine("Value of d = {0}", d);

            /* TryParse() */
            // But there is a problem when using Parse()
            bool varBool = default(bool);

            // // What if we try parsing some random string to a boolean?
            //varBool = bool.Parse("Mahirkoding.id"); // => run time error, FormatException

            // For safety, we need to put the Parse() inside a try catch block.
            try
            {
                varBool = bool.Parse("Mahirkoding.id");
                Console.WriteLine("Value of varBool = {0}", varBool);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message); // String was not recognized as a valid boolean
            }

            // To overcome this situation, there is an elegant way of doing this instead of using try catch block only for parsing.
            // TryParse() => will return false if it failed to parse the string.

            // Initialize with default value, which is "" for a string
            string strValue = default;

            // // This is wrong, just wrong!
            // nilaiStr = "Wrong";
            strValue = "False";

            // If parsing is succeeded, return true and spit the parsed value out into variable b
            if (bool.TryParse(strValue, out b))
            {
                // Parsing succeeded. Print the value of b
                Console.WriteLine("Value of b = {0}", b);
            }
            else
            {
                // Uh-oh, failed to parse!
                Console.WriteLine(@"Is ""{0}"" a valid boolean value?", strValue);
            }

            // Lets try converting a string representing a number to an int

            // // This will fail the parsing
            //strValue = "2937.97";

            strValue = "2938";
            if (int.TryParse(strValue, out i))
            {
                Console.WriteLine("Value of i = {0}", i);
            }
            else
            {
                Console.WriteLine(@"Failed to parse ""{0}"" to int", strValue);
            }
            #endregion
        }
    }
}
