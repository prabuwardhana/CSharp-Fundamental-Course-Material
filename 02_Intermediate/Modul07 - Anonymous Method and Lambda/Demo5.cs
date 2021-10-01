using System;
using System.Collections.Generic;

namespace AnonymousMethodLambda
{
    public class Demo5
    {
        public static void Run()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            Predicate<int> predicate = IsEvenNumber;
            List<int> evenNumber = list.FindAll(predicate);

            Console.Write("New list contains only even numbers: ");
            foreach (int i in evenNumber)
            {
                Console.Write("{0} ", i);
            }

            // Starting from C#7 we can use local function as a callback function
            /*******************************************************************************
            # ADVANTAGE OF USING LOCAL FUNCTION OVER LAMBDA
            # When creating a lambda, a delegate has to be created, which is an unnecessary allocation in this case. 
            # Local functions are really just functions, no delegates are necessary.
            # Also, local functions are more efficient with capturing local variables: 
            # lambdas usually capture variables into a class, while local functions can use a struct (passed using ref), 
            which again avoids an allocation.
            # This also means calling local functions is cheaper and they can be inlined, 
            # possibly increasing performance even further.
            *******************************************************************************/
            bool IsEvenNumber(int num)
            {
                return (num % 2) == 0;
            }

            /** OUTPUT **/
            /**********************************************
            # New list contains only even numbers: 20 4 8 44
            **********************************************/
        }
    }
}