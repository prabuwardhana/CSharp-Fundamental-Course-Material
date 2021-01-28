using System;

namespace ClassAndStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkingWithClass();
            WorkingWithStruct();
        }

        private static void WorkingWithClass()
        {
            // Declaring an instance variable
            // We are not allowed to access any member of this instance variable before creating an instance of Car class.
            Car lamboCar;
            // Instantiate an object of Car class by calling the default constructor
            lamboCar = new Car();
            // // Or.. we can just do it in a single line like this:
            // Car mobilLambo = new Car();

            Console.Write("Before initializing the fields: ");
            // Accessing the member of lamboCar object
            Console.WriteLine("Car type: {0}, Current speed: {1}", lamboCar.type, lamboCar.currentSpeed);
            Console.Write("Initialize fields => ");
            lamboCar.type = "Lamborghini Aventador";
            lamboCar.currentSpeed = 0;
            Console.Write("After initialization => ");
            Console.WriteLine("Car type: {0}, Current speed: {1}", lamboCar.type, lamboCar.currentSpeed);

            for (int i = 0; i < 10; i++)
            {
                lamboCar.Accelerate(20);
                lamboCar.ShowStatus();
            }

            Console.Write("Creating a new object, and initialize the value using constructor => ");
            Car ferrariCar = new Car("Ferrari Portofino", 0);
            
            Console.WriteLine("Car typ: {0}, Current speed: {1}", ferrariCar.type, ferrariCar.currentSpeed);

            for (int i = 0; i < 10; i++)
            {
                ferrariCar.Accelerate(20);
                ferrariCar.ShowStatus();
            }
        }

        private static void WorkingWithStruct()
        {
            // Declaring an instance variable
            // It is not allowed to access a member of this struct before initializing it
            MotorBike motorBike;
             
            // Inialize member fields
            // Now we can access these fields.
            // Notice that we didn't even need to instantiate an object.
            // That is because unlike a class, a struct is a value type!
            motorBike.type = "";
            motorBike.currentSpeed = 0;

            // // Initializing all the member field of a struct can be troublesome
            // // C# provides us a more concise way to do it. Using new keyword as if we are initializing an object.
            // // Unlike with a class, new keyword with a struct is used to initialize all the member fields, not to instantiate an object.
            // MotorBike motorBike = new MotorBike();

            Console.Write("Without explicit initialization: ");
            Console.WriteLine("Motorbike type: {0}, Current speed: {1}", motorBike.type, motorBike.currentSpeed);
            Console.Write("Initializing member fields => ");
            motorBike.type = "Harley Davidson";
            motorBike.currentSpeed = 0;
            Console.Write("After initialization => ");
            Console.WriteLine("Motorbike type: {0}, Current speed: {1}", motorBike.type, motorBike.currentSpeed);

            for (int i = 0; i < 10; i++)
            {
                motorBike.Accelerate(20);
                motorBike.ShowStatus();
            }

            MotorBike motorHD = new MotorBike("Harley Davidson", 0);
            Console.Write("Initialize member fields using constructor => ");
            Console.WriteLine("Motorbike type: {0}, Current speed: {1}", motorBike.type, motorBike.currentSpeed);

            for (int i = 0; i < 10; i++)
            {
                motorHD.Accelerate(20);
                motorHD.ShowStatus();
            }
        }
    }
}
