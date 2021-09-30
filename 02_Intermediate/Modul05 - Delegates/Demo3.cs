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

    /************************************
    # We can assign to delegates not only methods that have matching signatures, 
    # but also methods that return more derived types (covariance) or 
    # that accept parameters that have less derived types (contravariance) 
    # than that specified by the delegate type.
    ************************************/

    delegate Vehicle VehicleDelegate();
    delegate void BusDelegate(Bus bus);

    public class Demo3
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Covariance In Delegate ===");
            // Instantiate object of Vehicle class.
            Vehicle vehicleObj = new Vehicle();
            // Instantiate object of Bus class which inherits Vehicle class.
            Bus busObj = new Bus();

            // NORMAL CASE
            // VehiclaDelegate expects a method that returns Vehicle.
            VehicleDelegate vehicleDelegate1 = vehicleObj.CreateNewVehicle;
            Vehicle myVehicle = vehicleDelegate1();

            /************************************
            # COVARIANCE
            # Even the VehiclaDelegate expects a method that returns Vehicle,
            # we can assign a method with a return type Bus.
            # busObj.CreateNewBus RETURNS an object of type Bus which is more derived types
            # than an object of type Vehicle
            ************************************/
            VehicleDelegate vehicleDelegate2 = busObj.CreateNewBus;
            Bus myBus = vehicleDelegate2() as Bus;

            /** OUTPUT **/
            /************************************
            # === Covariance In Delegate ===
            # Inside Vehicle.CreateNewVehicle, a vehicle object is created.
            # Inside Bus.CreateNewBus, a bus object is created.
            ************************************/

            Console.WriteLine("\n=== Contravariance In Delegate ===");
            // NORMAL CASE
            // BusDelegate expects a method that accept object of type Bus as parameter.
            BusDelegate busDelegate1 = myBus.ShowBus;
            // Passing object of type Bus as parameter.
            busDelegate1(myBus);

            /************************************
            # CONTRAVARIANCE
            # Even the busDelegate expects a method that accepts object of type Bus as param,
            # it still can point to a method that accepts object of type Vehicle as param.
            # myVehicle.ShowVehicle ACCEPT an object of type Vehicle which is less derived types
            # than an object of type Bus.
            ************************************/
            BusDelegate busDelegate2 = myVehicle.ShowVehicle;
            busDelegate2(myBus);

            // // However, we CANNOT PASS an objet of type Vehicle to the delegate
            // busDelegate2(myVehicle);

            /** OUTPUT **/
            /************************************
            # === Contravariance In Delegate ===
            # Bus.ShowBus is called.
            # myBus.GetHashCode() is: 58225482 // the hashcode will vary
            # Vehicle.ShowVehicle is called.
            # myVehicle.GetHashCode() is: 58225482 // the hashcode will vary
            ************************************/
        }
    }
}