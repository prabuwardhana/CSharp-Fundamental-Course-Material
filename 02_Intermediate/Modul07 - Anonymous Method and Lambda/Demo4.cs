using System;

namespace AnonymousMethodLambda
{
    public delegate void MathMessage(string msg, int result);

    public class SimpleMath
    {
        private MathMessage mathMsgDelegate;

        public void RegisterMathHandler(MathMessage targetMethod)
        {
            mathMsgDelegate = targetMethod;
        }

        public void Add(int x, int y)
        {
            mathMsgDelegate?.Invoke("Adding operation has done!", x + y);
        }
    }

    public class Demo4
    {
        public static void Run()
        {
            SimpleMath simpleMath = new SimpleMath();

            // simpleMath.RegisterMathHandler expects a callback function
            // that match the MathMessage delegate signature
            simpleMath.RegisterMathHandler((msg, result) =>
            {
                Console.WriteLine("Message: {0}, Result: {1}", msg, result);
            });

            // This will execute the lambda expression (callback function)
            simpleMath.Add(10, 10);

            /** OUTPUT **/
            /**********************************************
            # Message: Adding operation has done!, Result: 20
            **********************************************/
        }
    }
}