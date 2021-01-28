using System;

namespace WorkingWithMethod
{
    class Program
    {
        // void: state that a method has no return value
        // string[] args: state that this method has one parameter called args of type array of strings
        // Method signature -> [return value] [Method Name] ([Parameter(s)])
        static void Main(string[] args)
        {
            /* Calling a method */
            Console.WriteLine("\n=== Calling a Simple Method Without Return Value And Parameter ===");
            Halo();

            Console.WriteLine("\n=== Calling a Method With Return Value And Parameter ===");
            // The number 4 is the argument for x parameter
            // The number 5 is the argument for y parameter
            int sumResult = Addition(4, 5);
            Console.WriteLine($"4 + 5 = {sumResult}");
            // Directly access the return value
            Console.WriteLine($"4 + 5 = {Addition(4, 5)}");

            // Console.WriteLine($"4 + 10 = {Addition(4)}");

            // // Output: 4 + 10 = 14

            int substractResult = Substraction(10, 5);
            Console.WriteLine($"10 - 5 = {substractResult}");
            Console.WriteLine($"10 - 5 = {Substraction(10, 5)}");

            // Calling a method as a condition for if statement
            if (IsEqualNumber(5, 5))
            {
                Console.WriteLine("The numbers are equal");
            }
            else
            {
                Console.WriteLine("The numbers are not equal");
            }

            /* Calling a method without parameter modifier (pass by value) */
            Console.WriteLine("\n=== Pass By Value ===");
            int x = 9, y = 10;

            Console.WriteLine($"Before calling Multiplication(): value of x = {x}, value of y = {y}");
            Console.WriteLine($"Calling Multiplication(): multiplication result = {Multiplication(x, y)}");
            Console.WriteLine($"After calling Multiplication(): value of x = {x}, value of y = {y}");

            /* Calling a method with ref parameter modifier (pass by reference) */
            Console.WriteLine("\n=== Pass By Value ===");
            string str1 = "Flip", str2 = "Flop";

            Console.WriteLine($"Before calling SwapString(): str1 = {str1}, str2 = {str2}");
            SwapString(ref str1, ref str2);            
            Console.WriteLine($"After calling SwapString(): str1 = {str1}, str2 = {str2}");

            // string str1, str2;
            // SwapString(ref str1, ref str2);

            /* Ref Local and Return*/
            string[] stringArray = { "one", "two", "three" };
            int pos = 1;
            Console.WriteLine("\n=== simple Return ===");
            Console.WriteLine("Before the call: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);
            // The value of the array at pos position is only copied to output variable
            // We don't get the reference to the actual element itself
            string output = SimpleReturn(stringArray, pos);
            // This doesn't mutate stringArray at all
            output = "new";
            Console.WriteLine("After the call: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);
            
            Console.WriteLine("\n=== ref local and ref Return ===");
            Console.WriteLine("Before the call: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);
            // Now we are getting the reference to the element at pos
            ref var refOutput = ref RefReturn(stringArray, pos);
            // Mutate the value at pos
            refOutput = "new";
            Console.WriteLine("After the call: {0}, {1}, {2}", stringArray[0], stringArray[1], stringArray[2]);

            /* Using params modifier */
            Console.WriteLine("\n=== Using params modifiers ===");
            // Normally we do this
            double[] doubleArray = { 5.2, 8.3, 12.1, 96.4 };
            Console.WriteLine("Average value of doubleArray's elements: {0}", CalculateAvg(doubleArray));
            // // But.. can we do this?
            // // Of course not! CalculateAvg() defines only one parameter of type double[]
            // // By doing this, we pass four parameters to the method and it is not allowed.
            // Console.WriteLine("Average value of doubleArray's elements: {0}", CalculateAvg(5.2, 8.3, 12.1, 96.4));

            // We need to modify the parameter using params modifier
            // Then we can pass any number of argument with the same data type
            Console.WriteLine("Average value of all arguments: {0}", CalculateAvgParams(5.2, 8.3, 12.1, 96.4));
            Console.WriteLine("Average value of doubleArray's elements: {0}", CalculateAvgParams(doubleArray));

            /* Using out modifier */
            Console.WriteLine("\n=== Using out modifiers ===");
            int num1 = 10, num2 = 15;
            // int result;
            // AdditionWithOut(num1, num2, out result);
            // Or...
            // Declare the out variable in the parameter
            AdditionWithOut(num1, num2, out int result);
            Console.WriteLine($"{num1} + {num2} = {result}");

            // Is it allowed to assign a variable to be used as argument to out parameter?
            // Let see if we can do it!
            int anotherResult = 10;
            // Seems like we are allowed to do that
            // But.. try to uncomment the line of code inside the method definition.
            IncrementNum(10, out anotherResult);

            /* Using optional parameter */
            Console.WriteLine("\n=== Using optional parameter ===");
            // msg parameter is defined as optional by assigning default value
            // no obligation to pass an argument
            OptionalParameter("I develop software application"); 
            // But if you want, you can
            OptionalParameter("I design user interface", "Designer");

            /* Using named argument */
            Console.WriteLine("\n=== Using named argument ===");            
            // When called normally, the order of the arguments must match the order of the defined parameter
            PrintOrderDetail("Slamet", 001, "Fried Chicken");
            // // No problem, both first and third argument are expecting a string
            // // But, the order just doesn't make sense, right?
            PrintOrderDetail("Fried Chicken", 001, "Slamet");
            // // This is going to be an error
            // // We pass an int as argument to first parameter which expecting only string
            // PrintOrderDetail(001, "Slamet", "Fried Chicken");

            // Using named argument, we don't need to bother with the order.
            PrintOrderDetail(orderNum: 001, sellerName: "Slamet", itemName: "Fried Chicken");
            PrintOrderDetail(itemName: "Fried Chicken", sellerName: "Slamet", orderNum: 001);

            // // When mixed with nameless argument (positional argument),
            // // the argument must be put before all the named argument.
            
            // // Error! First parameter is expecting a string, but we pass an int. 
            // PrintOrderDetail(31, "Fried Chicken", namaPenjual: "Slamet");
            // // Error! We put the named argument before the nameless arguments
            // PrintOrderDetail(namaBarang: "Bebek Goreng", "slamet", 31);

            // These lines of code are fine
            PrintOrderDetail("slamet", 31, itemName: "Bebek Goreng");
            PrintOrderDetail(sellerName: "Slamet", 31, "Bebek Goreng");
            PrintOrderDetail("Slamet", itemName: "Bebek Goreng", orderNum: 31);

            /* Method overloading */
            Console.WriteLine("\n=== Method overloading ===");   

            // Calling int version of OverloadAddition()
            Console.WriteLine($"Addition of two ints: {OverloadAddition(10, 5)}");

            // Calling double version of OverloadAddition()
            Console.WriteLine($"Addition of two doubles: {OverloadAddition(9.5, 2.75)}");

            // Calling long version of OverloadAddition()
            Console.WriteLine($"Addition of two longs: {OverloadAddition(900000000000, 900000000000)}");

            /* Recursive method */
            Console.WriteLine($"Factorial of 5 = {NonRecursiveFactorial(5)}");
            Console.WriteLine($"Factorial of 5 = {Factorial(5)}");

            /* Using Array as return value*/
            string[] strArr = GetArrayValue();
            foreach (string str in strArr)
            {
                Console.Write(str);
            }
        }

        #region METHOD DECLARATION

        #region METHOD WITHOUT RETURN VALUE AND PARAMETER
        static void Halo()
        {
            Console.WriteLine("Hello, Mahirkoding.id!");
        }
        #endregion

        #region METHOD WITH RETURN VALUE AND PARAMETER
        // int: return value
        // x dan y: parameters
        // return: value that is returned to the caller, must match the defined data type.
        static int Addition(int x, int y)
        {
            return x + y;
        }
        #endregion

        #region EXPRESSION-EMBODIED MEMBER
        //expression-embodied member
        // => : lambda operator
        static int Substraction(int x, int y) => x + y;

        static bool IsEqualNumber(int x, int y) => x == y;
        #endregion

        #region PASS BY VALUE
        static int Multiplication(int x, int y)
        {
            int result = x * y;

            // change x dan y value
            x = 100;
            y = 25;

            return result;
        }
        #endregion

        #region PASS BY REFERENCE
        static void SwapString(ref string str1, ref string str2)
        {
            string tempStr = str1;
            str1 = str2;
            str2 = tempStr;
        }
        #endregion

        #region REF LOCAL AND RETURN
        static string SimpleReturn(string[] strArray, int position)
        {
            return strArray[position];
        }

        static ref string RefReturn(string[] strArray, int position)
        {
            return ref strArray[position];
        }
        #endregion

        #region PARAMS
        static double CalculateAvg(double[] value)
        {
            double sum = 0;
            if (value.Length == 0)
                return sum;
            for (int i = 0; i < value.Length; i++)
                sum += value[i];
            return (sum / value.Length);
        }

        static double CalculateAvgParams(params double[] value)
        {
            double sum = 0;
            if (value.Length == 0)
                return sum;
            for (int i = 0; i < value.Length; i++)
                sum += value[i];
            return (sum / value.Length);
        }
        #endregion

        #region METHOD WITH OUT MODIFIER
        static void AdditionWithOut(int x, int y, out int result)
        {
            result = x + y;
        }

        static void IncrementNum(int increment, out int result)
        {
            // // Can't do this
            // // Eror! out parameter is used but has never been initialized
            // // But, we have already assigned it by passing an argument, right?
            // // passing variable with a value as argument is allowed, but it is useless.
            // // out parameter is used to output something in the method not for receiving an argument.
            // result = result + increment;

            result = 0;
        }
        #endregion

        #region METHOD WITH OPTIONAL PARAMETER
        static void OptionalParameter(string msg, string msgSender = "Programmer")
        {
            Console.WriteLine("Message sender: {0}", msgSender);
            Console.WriteLine("Message: {0}", msg);
        }

        // You can't do this!
        // DateTime.Now is evaluated at runtime, not at compile time.
        // Optional parameter must be assigned with a value that is evaluated at compile time.
        //static void LogMessage(string msg, string msgSender = "Programmer", DateTime time = DateTime.Now)
        //{
        //    // Writing a log message
        //}
        #endregion

        #region METHOD TO BE CALLED WITH NAMED ARGUMENT
        static void PrintOrderDetail(string sellerName, int orderNum, string itemName)
        {            
            // Check whether sellerName has a value or not (empty)
            if (string.IsNullOrWhiteSpace(sellerName))
            {
                // If it is an empty string, throw an exception
                throw new ArgumentException("Seller name cannot be empty!", nameof(sellerName));
            }

            Console.WriteLine($"Seller: {sellerName}, Order Number: {orderNum}, Item Name: {itemName}");
        }
        #endregion

        #region METHOD OVERLOADING
        // Karena method-method di bawah ini menggunakan tipe data yang berbeda-beda untuk nilai balik dan parameternya,
        // Anda mungkin berpikir untuk membuat beberapa method dengan nama yang berbeda, meskipun sebenarnya method-method tersebut
        // melakukan operasi yang sama. Yaitu, operasi penjumlahan.

        // These methods below are doing the same thing, adding two value and then return it.
        // But the problem is, for now you need to define three separate methods with three different names.
        // Can we do better?
        static int IntAddition(int x, int y) => x + y;

        static double DoubleAddition(double x, double y) => x + y;

        static long LongAddition(long x, long y) => x + y;

        // C# gives us flexibility to define several methods with the same name, but with different signature.
        // Meaning that the parameter can't be the same in number or data type.
        // This is called overloading.
        // Which method is used for each call, will be determined by the arguments when the method is called.
        // And it will be evaluated at compile time (static binding).
        static int OverloadAddition(int x, int y) => x + y;

        static double OverloadAddition(double x, double y) => x + y;

        static long OverloadAddition(long x, long y) => x + y;
        #endregion

        #region RECURSIVE METHOD
        // Calculating factorial
        // 5! = 5 x 4 x 3 x 2 x 1 = 120
        // n! = n x (n - 1)!

        // without recursive method
        static long NonRecursiveFactorial(int n)
        {
            if (n == 0) return 1;
            long value = 1;
            for (int i = n; i > 0; i--)
            {
                // nilai = nilai * i;
                value *= i;
            }

            return value;
        }

        // with recursive method
        // 5! = 
        // 1st call Factorial(5): 5 * Factorial(5 - 1)
        // 2nd call Factorial(5 - 1): 5 * 4 * Factorial(4 - 1)
        // 3rd call Factorial(4 - 1): 5 * 4 * 3 * Factorial(3 - 1)
        // 4th call Factorial(3 - 1): 5 * 4 * 3 * 2 * Factorial(2 - 1)
        // 5th call Factorial(2 - 1): 5 * 4 * 3 * 2 * 1 * Factorial(1 - 1)
        // 6th call Factorial(1 - 1): n = 0, no other recursive call and return 5 * 4 * 3 * 2 * 1 * 1, which is 120
        static long Factorial(int n)
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }
        #endregion

        #region ARRAY AS RETURN VALUE
        /* Using array as return value*/
        static string[] GetArrayValue()
        {
            string[] strArray = { "Hello ", "From ", "GetArrayValue()" };
            return strArray;
        }
        #endregion

        #endregion
    }
}
