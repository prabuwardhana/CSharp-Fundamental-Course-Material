using System;

namespace WorkingWithDelegates
{
    class Vehicle
    {
        public Vehicle CreateNewVehicle()
        {
            Vehicle vehicle = new Vehicle();
            Console.WriteLine("Inside Vehicle.CreateNewVehicle, a vehicle object is created.");
            return vehicle;
        }

        public void ShowVehicle(Vehicle vehicle)
        {
            Console.WriteLine("Vehicle.ShowVehicle is called.");
            Console.WriteLine("myVehicle.GetHashCode() is: {0}", vehicle.GetHashCode());
        }
    }

    class Bus : Vehicle
    {
        public Bus CreateNewBus()
        {
            Bus bus = new Bus();
            Console.WriteLine("Inside Bus.CreateNewBus, a bus object is created.");
            return bus;
        }

        public void ShowBus(Bus myBus)
        {
            Console.WriteLine("Bus.ShowBus is called.");
            Console.WriteLine("myBus.GetHashCode() is: {0}", myBus.GetHashCode());
        }
    }

    delegate Vehicle VehicleDelegate();
    delegate void BusDelegate(Bus bus);

    public class Demo3
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Covariance In Delegate ===");
            Vehicle vehicleObj = new Vehicle();
            Bus busObj = new Bus();

            // Normal case
            // vehiclaDelegate expects a method that returns Vehicle
            VehicleDelegate vehicleDelegate1 = vehicleObj.CreateNewVehicle;
            Vehicle myVehicle = vehicleDelegate1();

            // Covariance
            // even the vehiclaDelegate expects a method that returns Vehicle,
            // we can assign a method with a return type Bus
            VehicleDelegate vehicleDelegate2 = busObj.CreateNewBus;
            Bus myBus = vehicleDelegate2() as Bus;

            Console.WriteLine("\n=== Contravariance In Delegate ===");
            // Normal case
            BusDelegate busDelegate1 = myBus.ShowBus;
            busDelegate1(myBus);

            // Contravariance
            // even the busDelegate expects a method that accepts Bus object as param,
            // it still can point to a method that accepts Vehicle object as param
            BusDelegate busDelegate2 = myVehicle.ShowVehicle;
            busDelegate2(myBus);

            // // Cannot pass vehicle objet to the delegate
            // busDelegate2(myVehicle);
        }
    }
}