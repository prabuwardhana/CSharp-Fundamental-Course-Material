using System;
using CustomConversion.Helper;

namespace CustomConversion
{
    public class Demo2
    {
        public static void Run()
        {
            // Using explicit conversion operation on the Square type, 
            // we can now pass in Rectangle types for processing using an explicit cast
            Rectangle rect = new Rectangle(10, 5);
            DrawSquare((Square)rect);

            /** OUTPUT **/
            /*****************************************
            # [Length = 5]
            # *****
            # *****
            # *****
            # *****
            # *****
            ******************************************/
        }

        private static void DrawSquare(Square sq)
        {
            Console.WriteLine(sq.ToString());
            sq.Draw();
        }
    }
}