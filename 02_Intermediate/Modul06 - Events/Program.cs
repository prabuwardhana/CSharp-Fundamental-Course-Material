using System;

namespace WorkingWithEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            #region The correlation between delegate and event
            // Demo1.Run();                
            #endregion

            #region Using predefined EventHandler
            // Demo2.Run();                
            #endregion

            #region Custom event arguments and generic event handler
            // Demo3.Run();                
            #endregion

            #region Explicit event implementation
            // Demo4.Run();                
            #endregion

            #region Implementing interface event
            Demo5.Run();                
            #endregion
        }
    }
}
