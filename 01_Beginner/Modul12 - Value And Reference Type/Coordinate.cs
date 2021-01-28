using System;

namespace ValRefType
{
    public struct Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int x, int y)
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