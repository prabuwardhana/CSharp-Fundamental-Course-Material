namespace WorkingWithDelegates
{        
    class Program
    {
        static void Main(string[] args)
        {
            #region Simple delegate
            Demo1.Run();                
            #endregion
            
            #region Multicast delegate With void Return Type
            // Demo2.Run();                
            #endregion

            #region Covariance in delegate
            // Demo3.Run();                
            #endregion

            #region Generic delegate
            // Demo4.Run();                
            #endregion

            #region Covariant in generic delegate
            // Demo5.Run();                
            #endregion            
        }        
    }
}
