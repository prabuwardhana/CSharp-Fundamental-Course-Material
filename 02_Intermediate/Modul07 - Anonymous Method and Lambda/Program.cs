namespace AnonymousMethodLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Using private method as callback function
            Demo1.Run();
            #endregion

            #region Using anonymous method as callback function (C# 2.0)
            Demo2.Run();
            #endregion

            #region Using lambda expression as callback function (C# 3.0)
            // In general, applications that target .NET Framework 3.5 or later 
            // should use lambda expressions.
            Demo3.Run();
            Demo4.Run();
            #endregion

            #region Using local function as callback function (C# 7.0)
            Demo5.Run();
            #endregion
        }
    }
}
