using System;

namespace ShallowDanDeepCopy
{
    /* Implementing ICloneable */
    public class CloneablePoint : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public CloneablePoint() { }

        public CloneablePoint(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }

        public CloneablePoint(int xPos, int yPos, int zPos)
        {
            X = xPos;
            Y = yPos;
            Z = zPos;
        }

        public override string ToString() => $"X = {X}, Y = {Y}, Z = {Z}";

        // Return a new instance of ClonablePoint
        // // Z is not cloned
        // public object Clone() => new CloneablePoint(this.X, this.Y); 

        // // Clone X, Y, and Z
        // public object Clone() => new CloneablePoint(this.X, this.Y, this.Z);

        // Clone all value type members
        public object Clone() => this.MemberwiseClone();
    }

    public class Demo2
    {
        public static void Run()
        {
            CloneablePoint p1 = new CloneablePoint(100, 100);
            p1.Z = 50;
            Console.WriteLine("Value of each p1 member: {0}", p1);

            Console.WriteLine("=> Copy p1 to p2");
            CloneablePoint p2 = (CloneablePoint)p1.Clone();

            Console.WriteLine("=> Change p2.X value");
            p2.X = 10;
            Console.WriteLine("Value of each p4 member: {0}", p2);
        }
    }
}