namespace WorkingWithCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Limitation of Array type
            // Demo1.Run();
            #endregion

            #region Non-generic collections
            // Demo2.Run();
            // Demo2.BoxUnboxOp();
            #endregion

            #region List<T> Class
            Demo3.Run();
            #endregion

            #region Dictionary<TKey,TValue> Class
            // Demo4.Run();
            #endregion

            #region HashSet<T> Class
            // Demo5.Run();
            #endregion

            #region SortedSet<T> Class
            // Demo6.Run();
            // Demo6.ListFileInDirectory();
            #endregion

            #region Queue<T> Class
            // Demo7.Run();
            #endregion

            #region Stack<T> Class
            // Demo8.Run();
            #endregion
        }
    }
}