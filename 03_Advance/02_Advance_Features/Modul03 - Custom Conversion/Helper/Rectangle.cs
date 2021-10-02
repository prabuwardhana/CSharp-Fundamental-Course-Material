using System;

namespace CustomConversion.Helper
{
    public struct Rectangle
    {
        public int Width {get; set;}
        public int Height {get; set;}

        public Rectangle(int w, int h) : this()
        {
            Width = w;
            Height = h;
        }

        public void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                    Console.Write("*");

                Console.WriteLine();
            }
        }

        public override string ToString() => $"[Width = {Width}; Height = {Height}]";

        public static implicit operator Rectangle(Square s) => 
            new Rectangle 
            {
                Height = s.Length,
                Width = s.Length * 2 // Assume the length of the new Rectangle with (Length x 2).
            };
    }
}