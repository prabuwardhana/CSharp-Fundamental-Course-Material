using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace WorkingWithString
{
    class Program
    {
        static void Main(string[] args)
        {
            #region BASIC STRING MANIPULATION
            string name = "mahirkoding.id";

            Console.WriteLine("Value of variable 'name': {0}", name);
            Console.WriteLine("Variable 'name' has {0} characters", name.Length);
            Console.WriteLine("Uppercase transform of variable 'name': {0}", name.ToUpper());
            Console.WriteLine("Lowercase transform of variable 'name': {0}", name.ToLower());
            Console.WriteLine("Is there any \'m\' character in the value of variable 'name'?: {0}", name.Contains('m'));
            // Pass an integer as argument specifying the index.
            Console.WriteLine("Removing a character at spesific index in variable 'name': {0}", name.Remove(11));
            // The first argument is the starting index.
            // The second is the length of character you want to remove.
            Console.WriteLine("Deleting sequence of character starting at spesific index in variable 'name': {0}", name.Remove(5, 9));
            // The first argument is the index where the second argument will be inserted.
            // The second is a string you want to insert.
            Console.WriteLine("Inserting a character at specific index: {0}", name.Insert(5, "BANGET"));
            // Replace sequence of character with a new string.
            // The string in the first argument will be replaced by the string in the second argument.
            Console.WriteLine("Value of variable 'name' after replacement: {0}", name.Replace("id", "net"));

            // Note: String is an immutable object!
            // It means that you cannot change the value of string variable.
            // After sets of string manipulation above, the original value of variable 'name' remains unchanged.
            Console.WriteLine("Nilai variabel nama setelah memanggil method Replace(): {0}", name);
            #endregion

            #region STRING CONCATENATION
            string str1 = "Learning Programming at ";
            string str2 = "mahirkoding.id";
            // the + sign will be used by the compiler to call a static method called String.Concat().
            // Using + operator to concatenate string is a shortcut to String.Concat().
            string str3 = str1 + str2;
            // Concatenating two strings by calling String.Concat() directly.
            string str4 = System.String.Concat(str1, str2);
            Console.WriteLine(str3);
            Console.WriteLine(str4);
            #endregion

            #region ESCAPE CHARACTER
            Console.WriteLine("\n**** ESCAPE CHARACTER ****\n");

            Console.WriteLine("Single quote");
            Console.WriteLine("\'Hello mahirkoding.id\'\n");
            Console.WriteLine("Double");
            Console.WriteLine("\"I DEMAND FREEDOM!!\"\n");
            Console.WriteLine("Backslash");
            Console.WriteLine("C:\\MyApp\\bin\\debug\n");
            Console.WriteLine("Tabular");
            Console.WriteLine("ID\tName\tAddress\t");
            Console.WriteLine("0001\tSlamet\tYogyakarta\t");
            #endregion

            #region VERBATIM STRING
            Console.WriteLine("\n**** VERBATIM STRING ****\n");

            // Open the possibility to display string as is
            Console.WriteLine(@"C:\MyApp\bin\debug");
            // To display double quote, just type it twice.
            Console.WriteLine(@"The warrior shouted ""We demand freedom!!"" with full .");
            Console.WriteLine(
            @"\This
            \is a
            \'verbatim'
            \string");
            #endregion

            #region COMPARING TWO STRING
            Console.WriteLine("\n**** COMPARING TWO STRING ****\n");

            string str5 = "Hello!";
            Console.WriteLine("str5 = {0}", str5);
            string str6 = "Hi!";
            Console.WriteLine("str6 = {0}", str6);

            // Using Equality Operator
            // If both string are identical, it returns TRUE
            Console.WriteLine("str5 == str6 ? {0}", str5 == str6);
            Console.WriteLine("str5 == Hello! ? {0}", str5 == "Hello!");
            Console.WriteLine("str5 == HELLO! ? {0}", str5 == "HELLO!");
            Console.WriteLine("str5 == hello! ? {0}", str5 == "hello!");

            // Using Inequality Operator
            // If both string are not identical, it returns TRUE
            Console.WriteLine("str5 != str6 ? {0}", str5 != str6);
            Console.WriteLine("str5 != Hello! ? {0}", str5 != "Hello!");
            Console.WriteLine("str5 != HELLO! ? {0}", str5 != "HELLO!");
            Console.WriteLine("str5 != hello! ? {0}", str5 != "hello!");

            // Using String.Equals() method
            Console.WriteLine("str5.Equals(str6) ? {0}", str5.Equals(str6));
            Console.WriteLine("Hi.Equals(str6) ? {0}", "Hi!".Equals(str6));

            Console.WriteLine("\n");

            // By default, comparing two strings using equality/inequality operator is done by comparing each character
            // in case-sensitive and culture-insensitive way.

            // What the hell is culture-sensitive?
            string str7 = "encyclopædia";
            Console.WriteLine("str7 = {0}", str7);

            string str8 = "encyclopaedia";
            Console.WriteLine("str8 = {0}", str8);

            // This returns ja-JP in my PC.
            Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.Name);
            // This will evaluate to false.
            // 'æ' and 'ae' are considered as different character by the culture (your PC language & region setting).
            Console.WriteLine("str7 == str8 ? {0}", str7 == str8);
            // This time we use String.Equals method.
            // The first argument is the string we want to compare with.
            // The second is the comparison type.
            // This comparison will evaluate to TRUE, unless you remove the second argument.
            Console.WriteLine("str7.Equals(str8) ? (CurrentCulture): {0}", str7.Equals(str8, StringComparison.CurrentCulture));

            // Ignore the Thread stuff for now!
            // This line of code is only used to create a specific culture for a Thread running our code.
            // By default, the thread is running in ja-JP culture (again, my PC setting).
            // So I need to change the culture info for the thread running my code manually.
            // Nothing fancy!            
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.Name);

            Console.WriteLine("str7 = {0}", str7);
            Console.WriteLine("str8 = {0}", str8);
            Console.WriteLine("str7 == str8 ? {0}", str7 == str8);
            Console.WriteLine("str7.Equals(str8) ? (CurrentCulture): {0}", str7.Equals(str8, StringComparison.CurrentCulture));
            Console.WriteLine("str7.Equals(str8) ? (CurrentCultureIgnoreCase): {0}", str7.Equals(str8, StringComparison.CurrentCultureIgnoreCase));

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("se-NO");
            Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.Name);

            Console.WriteLine("str7.Equals(str8) ? (CurrentCulture): {0}", str7.Equals(str8, StringComparison.CurrentCulture));
            Console.WriteLine("str7.Equals(str8) ? (CurrentCultureIgnoreCase): {0}", str7.Equals(str8, StringComparison.CurrentCultureIgnoreCase));
            #endregion

            #region IMMUTABLE DAN MUTABLE STRING
            // String is immutable
            string aString = "This is a string";
            // This will create another string in a new memory location
            aString = aString + " and this is another string";

            // Using StringBuilder (mutable string)
            StringBuilder sb1 = new StringBuilder("This is a string");
            // This will mutate sb1 object at the same memory location
            sb1.Append(" and this is another string");
            sb1.Append("\n");
            sb1.AppendLine("A new string");
            sb1.AppendLine("This string is in the new line");
            Console.WriteLine(sb1.ToString());
            sb1.Remove(24, 5);
            Console.WriteLine(sb1.ToString());
            sb1.Replace("new", "newest");
            Console.WriteLine(sb1.ToString());
            sb1.Insert(0, "Hi, ");
            Console.WriteLine(sb1.ToString());
            #endregion

            #region STRING INTERPOLATION
            // Interpolasi string
            string nickname = "Joko";
            int age = 17;

            // Using placeholder syntax.
            Console.WriteLine("Hello! my nickname is {0}, I am {1} year(s) old", nickname, age);
            // Using string interpolation syntax.
            // Put the dollar sign in front of the double quote,
            // then we can directly use our variable inside the string.
            Console.WriteLine($"Hello! my nickname is {nickname}, I am {age} year(s) old");
            #endregion
        }
    }
}
