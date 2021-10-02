using System;
using CustomConversion.Helper;

namespace CustomConversion
{
    public class Demo1
    {
        public static void Run()
        {
            // Make a Rectangle.
            Rectangle r = new Rectangle(15, 4);
            Console.WriteLine(r.ToString());
            r.Draw();

            Console.WriteLine();

            // Convert r into a Square,
            // based on the height of the Rectangle.
            Square s = (Square)r;
            Console.WriteLine(s.ToString());
            s.Draw();

            /** OUTPUT **/
            /************************************************
            # [Width = 15; Height = 4]
            # ***************
            # ***************
            # ***************
            # ***************                                                                               
            # 
            # [Length = 4]   
            # ****
            # ****
            # ****
            # ****
            ************************************************/
        }
    }
}