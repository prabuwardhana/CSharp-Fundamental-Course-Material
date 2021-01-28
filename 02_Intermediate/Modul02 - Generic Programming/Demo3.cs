using System;

namespace GenericProgramming
{
    public class NonGenericPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public NonGenericPoint(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }

        public override string ToString() => $"[{X}, {Y}]";

        public void ResetPoint()
        {
            X = 0;
            Y = 0;
        }
    }

    public class GenericPoint<T>
    {
        public T X { get; set; }
        public T Y { get; set; }

        public GenericPoint(T xPos, T yPos)
        {
            X = xPos;
            Y = yPos;
        }

        public override string ToString() => $"[{X}, {Y}]";

        public void ResetPoint()
        {
            // // a generic type does not know the actual placeholders up front, which means it cannot safely
            // // assume what the default value will be
            // // Error! Cannot implicitly convert type 'type' to 'type'
            // X = 0;
            // Y = 0;
            // or:
            // X = null;
            // Y = null;
            X = default(T);
            Y = default(T);
        }
    }

    public class ClassWithGenericMember
    {
        public void Swap<T>(ref T a, ref T b)        
        {
            Console.WriteLine("=>Swap two {0} value", typeof(T));
            Console.WriteLine("Before swap: {0}, {1}", a, b);
            T temp = a;
            a = b;
            b = temp;
            Console.WriteLine("After swap: {0}, {1}\n", a, b);
        }

        public static void DisplayBaseClass<T>()
        {
            // Examine the base type of type T
            Console.WriteLine("Base class of {0} is: {1}.", typeof(T), typeof(T).BaseType);
        }
    }

    public class Demo3
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Generic Class ===");
            // Using non-generic class
            NonGenericPoint point = new NonGenericPoint(100, 100);
            // // Error! cannot convert from double to int
            // NonGenericPoint p = new NonGenericPoint(10.5, 15.2);
            Console.WriteLine($"Non-generic integer point: {point}");

            // Using generic class
            GenericPoint<int> intPoint = new GenericPoint<int>(100, 100);
            Console.WriteLine($"Generic integer point: {intPoint}");
            GenericPoint<double> doublePoint = new GenericPoint<double>(50.25, 25.75);
            Console.WriteLine($"Generic double point: {doublePoint}");

            Console.WriteLine("\n=== Non-generic Class With Generic Member ===");
            int x = 5, y = 10;
            // Generic method as a class member
            ClassWithGenericMember genericMember = new ClassWithGenericMember();
            genericMember.Swap<int>(ref x,ref y);

            // Using static member
            ClassWithGenericMember.DisplayBaseClass<double>();
        }
    }
}