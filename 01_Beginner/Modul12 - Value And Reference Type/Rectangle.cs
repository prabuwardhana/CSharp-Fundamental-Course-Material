using System;

namespace ValRefType
{
    public class GeometricInfo
    {
        public string InfoString;
        public GeometricInfo(string info)
        {
            InfoString = info;
        }
    }

    /* CREATING A STRUCT (VALUE TYPE) CONTAING A CLASS (REF TYPE) */
    public struct Rectangle
    {
        // Rectangle contains a reference type variable
        public GeometricInfo RectInfo;
        public int upperSide, leftSide, bottomSide, rightSide;

        public Rectangle(string info, int atas, int kiri, int bawah, int kanan)
        {
            RectInfo = new GeometricInfo(info);
            upperSide = atas;
            leftSide = kiri;
            bottomSide = bawah;
            rightSide = kanan;
        }
        public void Display()
        {
            Console.WriteLine("String = {0}, Top = {1}, Bottom = {2}, " +
            "Left = {3}, Right = {4}",
            RectInfo.InfoString, upperSide, bottomSide, leftSide, rightSide);
        }
    }
}