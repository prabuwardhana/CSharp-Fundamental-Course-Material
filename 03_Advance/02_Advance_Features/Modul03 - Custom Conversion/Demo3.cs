using System;
using CustomConversion.Helper;

namespace CustomConversion
{
    public class Demo3
    {
        public static void Run()
        {
            // Converting an int to a Square.
            Square sq2 = (Square)90;            
            Console.WriteLine("sq2 = {0}", sq2);            

            // Converting a Square to an int.
            int side = (int)sq2;
            Console.WriteLine("Side length of sq2 = {0}", side);

            /** OUTPUT **/
            /***********************************
            # sq2 = [Length = 90]
            # Side length of sq2 = 90
            ***********************************/

            Console.WriteLine();

            // Implicit cast OK!
            // converting Square type to Rectangle type can be done implicitly
            // as it is defined by the implicit operator
            Square s3 = new Square { Length= 7};
            Rectangle rect2 = s3;
            Console.WriteLine("rect2 = {0}", rect2);

            // Anyway, explicit cast syntax is still OK!
            Square s4 = new Square {Length = 3};
            Rectangle rect3 = (Rectangle)s4;
            Console.WriteLine("rect3 = {0}", rect3);
            
            /** OUTPUT **/
            /***********************************
            # rect2 = [Width = 14; Height = 7]
            # rect3 = [Width = 6; Height = 3]
            ***********************************/
        }
    }
}