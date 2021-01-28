using System;

namespace GenericProgramming
{
    interface IGenericInterface<T>
    {
        //A generic method
        T GenericMethod(T param);
        //A non-generic method
        void NonGenericMethod();
    }

    public class ConcreteGenericClass<T> : IGenericInterface<T>
    {
        public T GenericMethod(T param)
        {
            return param;
        }

        public void NonGenericMethod()
        {
            Console.WriteLine("Implementing NonGenericMethod of IGenericInterface<T>");
        }
    }
    
    class ConcreteGenericClass<U, T> : IGenericInterface<T>
    {
        public T GenericMethod(T param)
        {
            throw new NotImplementedException();
        }

        public void NonGenericMethod()
        {
            throw new NotImplementedException();
        }
    }

    // public class ConcreteGenericClass : IGenericInterface<T>{} => this definition is invalid

    public class Demo4
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Generic Interface ===");
            IGenericInterface<int> concreteInt = new ConcreteGenericClass<int>();
            int myInt = concreteInt.GenericMethod(5);
            Console.WriteLine($"The value stored in myInt is : {myInt}");
            concreteInt.NonGenericMethod();

            IGenericInterface<string> concreteStr = new ConcreteGenericClass<string>();
            string myStr = concreteStr.GenericMethod("Hello from mahirkoding.id!");
            Console.WriteLine($"The value stored in myStr is : {myStr}");
            concreteStr.NonGenericMethod();
        }
    }
}