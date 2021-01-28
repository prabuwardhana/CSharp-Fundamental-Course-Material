using System;

namespace WorkingWithDelegates
{
    //A generic delegate with covariant return type (out)
    delegate TResult CovDelegate<out TResult>();
    // A generic contravariant delegate (in)
    delegate void ContraDelegate<in T>(T param);

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
            Console.WriteLine("\n=== Covariant in Generic Delegate ===");
            Console.WriteLine("=> Normal usage (Covariance):");
            CovDelegate<Animal> covAnimalDelegate = GetOneAnimal;
            covAnimalDelegate();
            CovDelegate<Cat> covCatDelegate = GetOneCat;
            covCatDelegate();

            Console.WriteLine("=> Using covariance:");
            // We will receive a compile error if we do not use covariance delegate
            covAnimalDelegate = covCatDelegate;
            covAnimalDelegate();

            Animal animal = new Animal();
            Cat cat = new Cat();

            Console.WriteLine("\n=> Normal usage (Contravariance):");
            ContraDelegate<Animal> contraAnimal = ShowAnimalType;
            contraAnimal(animal);
            ContraDelegate<Cat> contraCat = ShowCatType;
            contraCat(cat);

            Console.WriteLine("=> Using contravariance:");
            // We will receive a compile error if we do not use contravariance delegate
            contraCat = contraAnimal;
            contraCat(cat);
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