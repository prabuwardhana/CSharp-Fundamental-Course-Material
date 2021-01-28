using System;

namespace GenericProgramming
{
    class BaseClass<T>
    {
        public virtual T MyMethod(T param)
        {
            Console.WriteLine("Inside BaseClass.BaseMethod()");
            return param;
        }
    }

    class DerivedClass<T>: BaseClass<T>
    {
        public override T MyMethod(T param)
        {
            Console.WriteLine("Here I'm inside of DerivedClass.DerivedMethod()");
            return param;
        }
    }

    public class Demo6
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Overriding Generic Method ===");
            BaseClass<int> intBase = new BaseClass<int>();
            Console.WriteLine($"Base class method returns {intBase.MyMethod(25)}");

            intBase = new DerivedClass<int>();
            Console.WriteLine($"Derived class method returns {intBase.MyMethod(25)}");

            // // cannot point to an object that is dealing with different types (double in this case).
            // // The following will cause compile-time error
            // intBase = new DerivedClass<double>();

            BaseClass<double> doubleBase = new DerivedClass<double>();
            Console.WriteLine($"Derived class method returns {doubleBase.MyMethod(12.75)}");
        }
    }
}