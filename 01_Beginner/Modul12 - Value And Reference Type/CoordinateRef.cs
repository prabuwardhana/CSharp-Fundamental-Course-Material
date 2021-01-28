using System;

namespace ValRefType
{
    public class CoordinateRef
    {
        public int X;
        public int Y;

        public CoordinateRef(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void DisplayCoordinate()
        {
            Console.WriteLine("Coordinate value: X = {0}, Y = {1}", X, Y);
        }
    } 
}