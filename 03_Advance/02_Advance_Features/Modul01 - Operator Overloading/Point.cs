using System;

namespace OperatorOverloading
{
    class Point : IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }

        // override object.ToString
        public override string ToString() => $"[{this.X}, {this.Y}]";

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Point)
            {
                Point temp = (Point)obj;

                if (temp.X == this.X && temp.Y == this.Y)
                    return true;
                else
                    return false;
            }

            return false;
        }

        // override object.GetHashCode
        public override int GetHashCode() => this.ToString().GetHashCode();

        public int CompareTo(Point other)
        {
            if (this.X > other.X && this.Y > other.Y)
                return 1;
            else if (this.X < other.X && this.Y < other.Y)
                return -1;
            else
                return 0;
        }

        // Overloading binary operator
        public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);
        public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);

        // Overloading unary operator
        public static Point operator ++(Point p1) => new Point(p1.X + 1, p1.Y + 1);
        public static Point operator --(Point p1) => new Point(p1.X - 1, p1.Y - 1);

        // Overloading equality operator
        public static bool operator ==(Point p1, Point p2) => p1.Equals(p2);
        public static bool operator !=(Point p1, Point p2) => !p1.Equals(p2);

        // Overloading Comparison Operators
        public static bool operator >(Point p1, Point p2) => p1.CompareTo(p2) > 0;
        public static bool operator <(Point p1, Point p2) => p1.CompareTo(p2) < 0;
        public static bool operator >=(Point p1, Point p2) => p1.CompareTo(p2) >= 0;
        public static bool operator <=(Point p1, Point p2) => p1.CompareTo(p2) <= 0;
    }
}
