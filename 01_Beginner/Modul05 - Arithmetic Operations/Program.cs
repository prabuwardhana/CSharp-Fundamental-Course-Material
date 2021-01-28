using System;

namespace ArithmeticOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            #region USING ARITHMETIC OPERATOR
            int num1 = 10, num2 = 20;
            int addition = 0, subtraction = 0, multiplication = 0, modulus = 0;
            double pembagian = default(double);

            // "num1" and "num2" are called the operand
            // "num1 + num2" is called an expression
            // "addition = num1 + num2 "is called a statement

            addition = num1 + num2;
            Console.WriteLine("{0} + {1} = {2}", num1, num2, addition);

            subtraction = num2 - num1;
            Console.WriteLine("{0} - {1} = {2}", num1, num2, subtraction);

            multiplication = num1 * num2;
            Console.WriteLine("{0} x {1} = {2}", num1, num2, multiplication);

            pembagian = num1 / num2;
            Console.WriteLine("{0} : {1} = {2}", num1, num2, pembagian);

            double bilDesimal1 = 10, bilDesimal2 = 20;
            pembagian = bilDesimal1 / bilDesimal2;
            Console.WriteLine("{0} : {1} = {2}", bilDesimal1, bilDesimal2, pembagian);

            modulus = num1 % num2;
            Console.WriteLine("{0} % {1} = {2}", num1, num2, modulus);
            #endregion

            #region SIMPLIFYING ARITHMETIC NOTATION
            int x = 0, y = 0;

            x = y = 5;

            // x = x + y
            Console.WriteLine("Nilai x = {0}", x += y); // x = 10

            // x = x - y
            Console.WriteLine("Nilai x = {0}", x -= y); // x = 5

            // x = x * y
            Console.WriteLine("Nilai x = {0}", x *= y); // x = 25

            // x = x / y
            Console.WriteLine("Nilai x = {0}", x /= y); // x = 5

            // x = x % y
            Console.WriteLine("Nilai x = {0}", x %= y); // x = 0
            #endregion

            #region INCREMENT DAN DECREMENT
            x = y = 5;

            // x = x + 1
            // post-increment : give me the value of x, then I increment it.
            Console.WriteLine("Nilai x = {0}", x++); // x = 0
            Console.WriteLine("Nilai x = {0}", x); // x = 1
            // pre-increment : I increment the value of y, then give the value to you.
            Console.WriteLine("Nilai x = {0}", ++y); // y = 1

            // x = x - 1
            // post-increment : give me the value of x, then I decrement it.
            Console.WriteLine("Nilai x = {0}", x--); // x = 0
            Console.WriteLine("Nilai x = {0}", x); // x = 1
            // pre-increment : I decrement the value of y, then give the value to you.
            Console.WriteLine("Nilai x = {0}", --y); // y = 1

            // x++ is an expression and a statement at the same time.

            // Elaborating pre and post increment
            x = y = 5;

            // The value of x will be incremented first, then its value is compared to 6.
            // It is true anyway!
            if (++x == 6)
            {
                Console.WriteLine("nilai x sama dengan 6");
            }

            // The value of x will be compared first, then its value is incremented by 1.
            // 6 is not equal to 7. Then, it is true anyway! (Notice the inequality operator !=)
            if (x++ != 7)
            {
                Console.WriteLine("nilai x tidak sama dengan 7");
            }
            #endregion
        }
    }
}
