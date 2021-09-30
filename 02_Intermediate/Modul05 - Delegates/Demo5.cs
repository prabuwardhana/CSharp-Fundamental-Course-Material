using System;

namespace WorkingWithDelegates
{
    // A generic delegate with covariant return type (out)
    // TResult can be only returned as method results
    delegate TResult CovariantDelegate<out TResult>();
    // A generic contravariant delegate (in)
    // T can be only passed as a parameter to a method
    delegate void ContravariantDelegate<in T>(T param);

    class Animal
    {
        public virtual void ShowMe()
        {
            Console.WriteLine(" Animal.ShowMe()");
        }
    }

    class Cat : Animal
    {
        public override void ShowMe()
        {
            Console.WriteLine(" Cat.ShowMe()");
        }
    }

    public class Demo5
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Covariance in Generic Delegate ===");
            Console.WriteLine("=> Normal usage:");
            CovariantDelegate<Animal> covAnimalDelegate = GetOneAnimal;
            covAnimalDelegate();
            CovariantDelegate<Cat> covCatDelegate = GetOneCat;
            covCatDelegate();

            Console.WriteLine("=> Using covariance:");
            // We will receive a compile error if we do not use covariance delegate
            covAnimalDelegate = covCatDelegate;
            covAnimalDelegate();

            /** OUTPUT **/
            /************************************
            # === Covariance in Generic Delegate ===
            # => Normal usage:
            # Creating one animal and returning it.
            # Creating one cat and returning it.
            # => Using covariance:
            # Creating one cat and returning it.
            ************************************/

            Console.WriteLine("\n=== Contravariance in Generic Delegate ===");

            Animal animal = new Animal();
            Cat cat = new Cat();

            Console.WriteLine("\n=> Normal usage:");
            ContravariantDelegate<Animal> contraAnimal = ShowAnimalType;
            contraAnimal(animal);
            ContravariantDelegate<Cat> contraCat = ShowCatType;
            contraCat(cat);

            Console.WriteLine("=> Using contravariance:");
            // We will receive a compile error if we do not use contravariance delegate
            contraCat = contraAnimal;
            contraCat(cat);

            /** OUTPUT **/
            /************************************
            # === Contravariance in Generic Delegate ===
            # => Normal usage:
            #  Animal.ShowMe()
            #  Cat.ShowMe()
            # => Using contravariance:
            #  Cat.ShowMe()
            ************************************/
        }

        private static void ShowCatType(Cat cat)
        {
            cat.ShowMe();
        }

        private static void ShowAnimalType(Animal animal)
        {
            animal.ShowMe();
        }

        private static Cat GetOneCat()
        {
            Console.WriteLine("Creating one cat and returning the cat.");
            return new Cat();
        }

        private static Animal GetOneAnimal()
        {
            Console.WriteLine("Creating one animal and returning it.");
            return new Animal();
        }
    }
}