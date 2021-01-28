namespace ShallowDanDeepCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Simple Clone
            Demo1.Run();
            #endregion

            #region Implementing ICloneable Interface
            // Demo2.Run();                
            #endregion

            #region Shallow And Deep Copy
            // Demo3.Run();                
            #endregion
        }
    }
}
