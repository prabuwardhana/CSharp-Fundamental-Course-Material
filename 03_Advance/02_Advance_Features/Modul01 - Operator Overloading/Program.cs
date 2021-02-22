using System;
using System.Diagnostics.CodeAnalysis;

namespace OperatorOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Operator on intrinsic type
            Demo1.Run();
            #endregion

            #region Overloading binary operator
            // Demo2.Run();
            #endregion

            #region Overloading unary operator
            // Demo3.Run();
            #endregion

            #region Overloading equality operator
            // Demo4.Run();
            #endregion

            #region Overloading comparison operator
            // Demo5.Run();
            #endregion
        }
    }
}
