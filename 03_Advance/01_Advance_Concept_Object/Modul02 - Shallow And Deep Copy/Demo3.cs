using System;

namespace ShallowDanDeepCopy
{
    public class PointDescription
    {
        public string name { get; set; }
        public Guid pointID { get; set; }

        public PointDescription()
        {
            name = "no-name";
            pointID = Guid.NewGuid();
        }
    }

    /* Shallow Copy dan Deep Copy */
    public class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        // Reference type member
        public PointDescription desc = new PointDescription();

        public Point() { }

        public Point(int xPos, int yPos, string name)
        {
            X = xPos;
            Y = yPos;
            desc.name = name;
        }

        public override string ToString() => $"X = {X}, Y = {Y}, Z = {Z}\nID = {desc.pointID}\nNama = {desc.name}\n";

        // Clone current object
        public object Clone()
        {
            // Shallow copy (MemberwiseClone only clones value type members)
            Point newPoint = (Point)this.MemberwiseClone();

            // Need to fill in the gaps to complete deep copy
            PointDescription currentDesc = new PointDescription();
            currentDesc.name = this.desc.name;
            newPoint.desc = currentDesc;
            return newPoint;
        }
    }

    public class Demo3
    {
        public static void Run()
        {
            Point p1 = new Point(100, 100, "Alpha");
            p1.Z = 150;  
            Point p2 = (Point)p1.Clone();

            Console.WriteLine("Before value modification:");
            Console.WriteLine("p1: {0}", p1);
            Console.WriteLine("p2: {0}", p2);

            Console.WriteLine("=> Modify the name of p2");
            p2.desc.name = "Beta";
            Console.WriteLine("=> Modify the value of p2.X");
            p2.X = 30;

            Console.WriteLine("\nAfter value modification:");
            Console.WriteLine("p1: {0}", p1);
            Console.WriteLine("p2: {0}", p2);
        }
    }
}