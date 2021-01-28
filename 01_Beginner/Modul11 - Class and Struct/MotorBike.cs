using System;

namespace ClassAndStruct
{
    public struct MotorBike
    {
        /* Field */
        // As in a class, a struct can also have fields as its member.
        // But, we are not allowed to initialized it as it is allowed for a class member.
        // public string motorBikeType = "harley"; // => not valid
        public string type;
        public int currentSpeed;

        /* Constructor */
        // Eror! Structs cannot contain explicit parameterless constructors
        // public Motor()
        // {

        // }

        // Constructor overloading
        // Defining constructor to initialize some member.
        public MotorBike(string type, int currentSpeed)
        {
            this.type = type;
            this.currentSpeed = currentSpeed;
        }

        /* Method */
        // We are also allowed to define methods for a struct
        public void ShowStatus() => Console.WriteLine($"{type} melaju pada kecepatan {currentSpeed} km/jam");
        public void Accelerate(int delta) => currentSpeed += delta;
    }
}