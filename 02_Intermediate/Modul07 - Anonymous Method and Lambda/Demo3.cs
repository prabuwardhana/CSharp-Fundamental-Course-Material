using System;
using System.Collections.Generic;

namespace AnonymousMethodLambda
{
    public class Demo3
    {
        public static void Run()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            /*--------------------------------------------
            # argument => statement to process argument
            # "i" is our parameter list
            # "(i % 2) == 0" is our statement to process "i"
            ----------------------------------------------*/
            // List<int> evenNumber = list.FindAll(i => (i % 2) == 0);

            /*--------------------------------------------
              Explicitly state the parameter type.
            ----------------------------------------------*/
            // List<int> evenNumber = list.FindAll((int i) => (i % 2) == 0);

            /*--------------------------------------------
              Processing Arguments Within Multiple Statements
            ----------------------------------------------*/
            List<int> evenNumber = list.FindAll((int i) =>
            {
                Console.WriteLine("Current value of variable i: {0}", i);
                return (i % 2) == 0;;
            });

            Console.Write("New list contains only even numbers: ");
            foreach (int i in evenNumber)
            {
                Console.Write("{0} ", i);
            }

            /** OUTPUT **/
            /**********************************************
            # Current value of variable i: 20
            # Current value of variable i: 1       
            # Current value of variable i: 4       
            # Current value of variable i: 8       
            # Current value of variable i: 9       
            # Current value of variable i: 44      
            # New list contains only even numbers: 20 4 8 44 
            **********************************************/
        }
    }

    /*************************************************************************************************************
    # Several things that are worth noting about lambda:
    # 1. lambdas are expressions that produce functional values.
    # 2. lambda values have unbounded life times - from the execution of the lambda expression 
    #    and as long as any reference to the value exists. That implies that any local variables used, 
    #     or “captured”, by the lambda from the enclosing method must be allocated on the heap. 
    #     Since the life time of the lambda value is not limited by the life time of the stack frame where it was produced, 
    #     the variables cannot be allocated on that stack frame.
    # 3. lambda expression requires that all external variables used in the body are definitely assigned
    #     at the time the lambda expression is executed. The moment of the first and the last use of a lambda
    #     are rarely deterministic, so the language assumes that lambda values can be used right after creation
    #     and as long as they are reachable. As a result a lambda value must be fully functional at the point of 
    #     its creation and all outer variables that it uses must be definitely assigned.
    # 4. lambdas do not have names and cannot be referred to symbolically. 
    #     In particular lambda expressions cannot be declared recursively.
    *************************************************************************************************************/
}