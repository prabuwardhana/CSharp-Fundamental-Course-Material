using System;

namespace ShallowDanDeepCopy
{
    /* Without implementing ICloneable */
    public class SimplePoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public SimplePoint(){}
        public SimplePoint(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }

        public override string ToString() => $"X = {X}, Y = {Y}";
    }
    
    public class Demo1
    {
        public static void Run()
        {
            SimplePoint p1 = new SimplePoint(50, 50);
            SimplePoint p2 = p1;

            //Changing p2.X will also change p1.X
            p2.X = 0;

            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
    }
}