using System;

namespace GenericProgramming
{
    class MyNonGenericClass
    {
        public static int count;
        public void IncrementMe()
        {
            Console.WriteLine($"Incremented value is : {++count}");
        }
    }

    class MyGenericClass<T>
    {
        public static int count;
        public void IncrementMe()
        {
            Console.WriteLine($"Incremented value is : {++count}");
        }
    }

    public class Demo8
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Static Fields In Context Of Generic Programming ===");
            Console.WriteLine("=>Using Non-generic Class");
            MyNonGenericClass myNonGenericObj1 = new MyNonGenericClass();
            for (int i = 0; i < 3; i++)
            {
                myNonGenericObj1.IncrementMe();
            }

            MyNonGenericClass myNonGenericObj2 = new MyNonGenericClass();
            for (int i = 0; i < 5; i++)
            {
                myNonGenericObj2.IncrementMe();
            }

            Console.WriteLine("=>Using Generic Class");
            MyGenericClass<int> myIntGenericObj = new MyGenericClass<int>();
            for (int i = 0; i < 3; i++)
            {
                myIntGenericObj.IncrementMe();
            }

            MyGenericClass<double> myDoubleGenericObj = new MyGenericClass<double>();
            for (int i = 0; i < 3; i++)
            {
                myDoubleGenericObj.IncrementMe();
            }

            MyGenericClass<string> myStringGenericClass = new MyGenericClass<string>();
            for (int i = 0; i < 3; i++)
            {
                myStringGenericClass.IncrementMe();
            }
        }
    }
}