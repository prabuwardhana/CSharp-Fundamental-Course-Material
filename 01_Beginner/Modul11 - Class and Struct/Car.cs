using System;

namespace ClassAndStruct
{
    public class Car
    {
        /* Field */
        // Field is a class level variable that represent the characteristic or state of an instance of a class
        // The public keyword is called the access modifier. It helps the class encapsulate its data.
        public string type;
        public int currentSpeed;

        // Basically, initializing field is the same as initializing a variable.        
        // These code below are also valid
        // public string tipeMobil = "Mobil";
        // public int currentSpeed = 0;

        /* Constructor */
        // Constructor is used to create an instance of a class. 
        // We instantiate an instance by calling the constructor with new keyword.

        // When we define a class, by default the compiler will generate a default constructor for us.
        // But, when we declare another constructor other than the default one, we need to explicitly declare a default constructor.
        public Car()
        {

        }

        // Constructor overloading
        // Defining other alternative to create an instance.
        // Often times we need to initialized some data for an instance. 
        // So we need to define a constructor that is able to do such thing.
        public Car(string type, int currentSpeed)
        {
            this.type = type;
            this.currentSpeed = currentSpeed;
        }

        /* Method */
        // Modeling the behaviour of a class instance with a method
        public void ShowStatus() => Console.WriteLine($"{type} is running at speed {currentSpeed} km/jam");
        public void Accelerate(int delta) => currentSpeed += delta;
    }
}