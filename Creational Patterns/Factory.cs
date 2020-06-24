using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Factory pattern - create objects without actually specifying the exact classes or
 encapsulate object creation*/
 //define an interface  for creating an object but let the subclasses decide which class to instantiate
namespace DesignPatterns
{
    interface Vehicle
    {
        void design();
        void manufacture();
    }
    public class Car : Vehicle
    {
        public void design()
        {
            Console.WriteLine("car is designed");
        }

        public void manufacture()
        {
            Console.WriteLine("car is being manufactured");
        }
    }
    public class Truck : Vehicle
    {
        public void design()
        {
            Console.WriteLine("Truck is designed");
        }

        public void manufacture()
        {
            Console.WriteLine("Truck is being manufactured");
        }
    }

    class Factory
    {
        public Vehicle vehicle = null;
        public Vehicle getVehicle(string vehicleType)
        {
            if (vehicleType.Equals("car"))
                vehicle = new Car();
            else if (vehicleType.Equals("truck"))
                vehicle = new Truck();
            return vehicle;
        }

    }
}
