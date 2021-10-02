using System;

namespace CustomConversion.Helper
{
    public struct Square
    {
        public int Length {get; set;}

        public Square(int l) : this()
        {
            Length = l;
        }

        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                    Console.Write("*");

                Console.WriteLine();
            }
        }

        public override string ToString() => $"[Length = {Length}]";

        /**************************************************************
        # Like the process of overloading an operator, 
        # conversion routines make use of the C# operator keyword, 
        # in conjunction with the explicit or implicit keyword, and must be defined as static.
        # The incoming parameter is the entity you are converting from, 
        # while the operator type is the entity you are converting to.
        # Signature:
        # public static explicit operator OperatorType(parameter)
        **************************************************************/        

        // Rectangles can be explicitly converted into Squares.
        public static explicit operator Square(Rectangle r) => new Square {Length = r.Height};

        // int can be explicitly converted into Squares.
        public static explicit operator Square(int sideLength) => new Square {Length = sideLength};

        // Square can be explicitly converted into int.
        public static explicit operator int (Square s) => s.Length;
    }
}