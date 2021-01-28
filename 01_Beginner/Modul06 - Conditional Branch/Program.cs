using System;

namespace ConditionalBranch
{
    class Program
    {
        static void Main(string[] args)
        {
            #region IF STATEMENT
            int number = 30;

            // The condition must be met to run the code inside the if statement
            if (number == 30)
            {
                Console.WriteLine("Number is 30");
            }
            #endregion

            #region CONDITIONAL OPERATOR
            /* EQUALITY OPERATOR */
            int age = 20;

            // If equal
            if (age == 17)
            {
                Console.WriteLine("You have the rights to vote");
            }

            string pass = "password";

            // If not equal
            if (pass != "password")
            {
                Console.WriteLine("Access denied!");
            }

            /* RELATIONAL OPERATOR */
            int mark;

            mark = 80;

            if (mark < 50)
            {
                Console.WriteLine("Your mark is below 50");
            }

            if (mark > 50)
            {
                Console.WriteLine("Your mark is above 50");
            }

            if (mark <= 50)
            {
                Console.WriteLine("Your mark is less than or equal to 50");
            }

            if (mark >= 50)
            {
                Console.WriteLine("Your mark is more than or equal to 50");
            }
            #endregion

            #region IF-ELSE STATEMENT AND TERNARY OPERATOR
            mark = 50;

            if (mark >= 60)
            {
                Console.WriteLine("You passed!");
            }
            else
            {
                Console.WriteLine("You failed!");
            }

            // The code above can be refactored using ternary operator
            // [condition] ? [first expression] : [second expression]
            Console.WriteLine(mark >= 60 ? "You passed!" : "You failed");
            #endregion

            #region LOGICAL OPERATOR
            /* LOGICAL OPERATOR */
            string user = "username";
            string pwd = "password";

            // Operator & (Logical AND)
            if (user == "username" & pwd == "password")
            {
                Console.WriteLine("You are logged in");
            }
            else
            {
                Console.WriteLine("Access denied!");
            }

            // Operator && (Short circuit logical AND)
            if (user == "username" && pwd == "password")
            {
                Console.WriteLine("You are logged in");
            }
            else
            {
                Console.WriteLine("Access denied!");
            }

            // Difference between using & and &&
            // note: The method SeconCondition() is defined below the main method
            // Run the code, analyse the output, find the difference!
            bool a = false & SecondCondition();
            Console.WriteLine("Value of a: {0}", a);

            Console.WriteLine("========================");

            bool b = true & SecondCondition();
            Console.WriteLine("Value of b: {0}", b);

            Console.WriteLine("========================");

            bool c = false && SecondCondition();
            Console.WriteLine("Value of c: {0}", c);

            Console.WriteLine("========================");

            bool d = true && SecondCondition();
            Console.WriteLine("Value of d: {0}", d);

            age = 3;
            int height = 110;

            // Operator | (Logical OR)
            if (age >= 3 | height >= 100)
            {
                Console.WriteLine("You are allowed to play");
            }
            else
            {
                Console.WriteLine("You are not allowed to play");
            }

            // Operator || (Short circuit logical OR)
            if (age >= 3 || height >= 100)
            {
                Console.WriteLine("You are allowed to play");
            }
            else
            {
                Console.WriteLine("You are not allowed to play");
            }

            // Difference between usin | and ||
            bool f = false | SecondCondition();
            Console.WriteLine("value of f: {0}", f);

            Console.WriteLine("========================");

            bool g = true | SecondCondition();
            Console.WriteLine("value of g: {0}", g);

            Console.WriteLine("========================");

            bool h = false || SecondCondition();
            Console.WriteLine("value of h: {0}", h);

            Console.WriteLine("========================");

            bool i = true || SecondCondition();
            Console.WriteLine("value of i: {0}", i);

            // Operator ^ (XOR)
            Console.WriteLine("'true' XOR 'true' is: {0}", true ^ true);    // output: False
            Console.WriteLine("'true' XOR 'false' is: {0}", true ^ false);   // output: True
            Console.WriteLine("'false' XOR 'true' is: {0}", false ^ true);   // output: True
            Console.WriteLine("'false' XOR 'false' is: {0}", false ^ false);  // output: False

            // Operator ! (NOT)
            age = 20;
            // Using realational operator to assigned a value to boolean variable
            bool isAdult = age >= 17;

            if (!isAdult)
            {
                Console.WriteLine("You are not old enough!");
            }
            #endregion

            #region IF-ELSE IF STATEMENT
            
            mark = 79;
            if (mark >= 0 && mark < 20)
            {
                Console.WriteLine("Your grade: E");
            }
            else if (mark >= 20 && mark < 40)
            {
                Console.WriteLine("Your grade: D");
            }
            else if (mark >= 40 && mark < 60)
            {
                Console.WriteLine("Your grade: C");
            }
            else if (mark >= 60 && mark < 80)
            {
                Console.WriteLine("Your grade: B");
            }
            else if (mark >= 80 && mark <= 100)
            {
                Console.WriteLine("Your grade: A");
            }
            else
            {
                Console.WriteLine("The given grade is outside the possible value");
            }
            #endregion

            #region SWITCH STATEMENT
            // Constant Pattern
            Console.Write("Choose your favorite fruit (apel/orange/banana): ");
            string pilihan = Console.ReadLine().ToLower();
            
            if (pilihan == "apel")
                Console.WriteLine("You choosed apel");
            else if (pilihan == "orange")
                Console.WriteLine("You choosed orange");
            else if (pilihan == "banana")
                Console.WriteLine("You choosed banana");
            else
                Console.WriteLine("You choosed another fruit");

            switch (pilihan)
            {
                case "apel":
                    Console.WriteLine("You choosed apel");
                    break;
                case "orange":
                    Console.WriteLine("You choosed orange");
                    break;
                case "banana":
                    Console.WriteLine("You choosed banana");
                    break;
                default:
                    Console.WriteLine("You choose another fruit");
                    break;
            }            

            // Type Pattern
            Console.WriteLine("1 [Integer (5)], 2 [Double (2.5)], 3 [String (\"Hi\")]");
            Console.Write("Insert your choice: ");
            string userInput = Console.ReadLine();
            object userChoice;

            switch (userInput)
            {
                case "1":
                    userChoice = 5;
                    break;
                case "2":
                    userChoice = 2.5;
                    break;
                case "3":
                    userChoice = "Hi";
                    break;
                default:
                    userChoice = 5;
                    break;
            }

            switch (userChoice)
            {
                case int varInt:
                    Console.WriteLine("You choosed integer with value of: {0}", varInt);
                    break;
                case double varDouble:
                    Console.WriteLine("You choosed double with value of: {0}", varDouble);
                    break;
                case string varStr:
                    Console.WriteLine("You choosed string with value of: {0}", varStr);
                    break;
                default:
                    Console.WriteLine("You choosed different thing");
                    break;
            }        

            // Using when clause
            Console.Write("Insert a number: ");
            string inputValue = Console.ReadLine();
            mark = int.TryParse(inputValue, out int n) ? n : -1;

            switch (mark)
            {
                // Eror! "The switch case has already been handled by a previous case."
                // case int i:
                //     // do something
                //     break;
                case int x when x >= 0 & x < 20:
                    Console.WriteLine("Your grade: E");
                    break;
                case int x when x >= 20 & x < 40:
                    Console.WriteLine("Your grade: D");
                    break;
                case int x when x >= 40 & x < 60:
                    Console.WriteLine("Your grade: C");
                    break;
                case int x when x >= 60 & x < 80:
                    Console.WriteLine("Your grade: B");
                    break;
                case int x when x >= 80 & x <= 100:
                    Console.WriteLine("Your grade: A");
                    break;
                default:
                    Console.WriteLine("The value can't be converted into valid grade");
                    break;
            }
            #endregion
        }

        static bool SecondCondition()
        {
            Console.WriteLine("This condition is also being evaluated");
            return true;
        }        
    }
}
