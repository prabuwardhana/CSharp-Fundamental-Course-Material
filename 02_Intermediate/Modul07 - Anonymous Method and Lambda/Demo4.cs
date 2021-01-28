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
            mathMsgDelegate?.Invoke("Operasi penambahan telah selesai!", x + y);
        }
    }

    public class Demo4
    {
        public static void Run()
        {
            SimpleMath sm = new SimpleMath();
            sm.RegisterMathHandler((msg, result) =>
            {
                Console.WriteLine("Pesan: {0}, Hasil: {1}", msg, result);
            });

            // This will execute the lambda expression
            sm.Add(10, 10);
        }
    }
}