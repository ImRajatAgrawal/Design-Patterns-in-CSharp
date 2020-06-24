using System;
//create families of related objects without specifying the concrete classes;
namespace DesignPatterns
{
    public interface Engine{
        void Design();
        void Manufacture();
        void test();
    }
    public interface Tyre {
        void Design();
        void Manufacture();
    }

    public class CarEngine : Engine
    {
        public void Design()
        {
            Console.WriteLine("Designed car Engine");
        }

        public void Manufacture()
        {
            Console.WriteLine("Manufactured car Engine");
        }

        public void test()
        {
            Console.WriteLine("Testing Car Engine");
        }
    }
    public class TruckEngine : Engine
    {
        public void Design()
        {
            Console.WriteLine("Designed Truck Engine");
        }

        public void Manufacture()
        {
            Console.WriteLine("Manufactured Truck Engine");
        }

        public void test()
        {
            Console.WriteLine("Testing Truck Engine");
        }
    }
    public class CarTyre : Tyre
    {
        public void Design()
        {
            Console.WriteLine("Designed car Tyre");
        }

        public void Manufacture()
        {
            Console.WriteLine("Manufactured car Tyre");
        }

       
    }
    public class TruckTyre : Tyre
    {
        public void Design()
        {
            Console.WriteLine("Designed Truck Tyre");
        }

        public void Manufacture()
        {
            Console.WriteLine("Manufactured Truck Tyre");
        }

     
    }
    public abstract class AbstractFactory
    {
        
        public abstract Engine getEngine();
        public abstract Tyre getTyre();
        private static AbstractFactory Factory = null;

        public static AbstractFactory getFactory(string VehicleType)
        {
            if (VehicleType.Equals("car"))
                Factory = new carFactory();
            else if (VehicleType.Equals("truck"))
                Factory = new truckFactory();
            return Factory;

        }

    }
    public class carFactory : AbstractFactory
    {
        public override Engine getEngine()
        {
            return new CarEngine();
        }

        public override Tyre getTyre()
        {
            return new CarTyre();
        }
    }

    public class truckFactory : AbstractFactory
    {
        public override Engine getEngine()
        {
            return new TruckEngine();
        }

        public override Tyre getTyre()
        {
            return new TruckTyre();
        }
    }
    public class Client
    {
        public static void Main(string[] args)
        {
            AbstractFactory factory;
            factory = AbstractFactory.getFactory("car");
            Engine carEngine = factory.getEngine();
            Tyre carTyre = factory.getTyre();

            carEngine.Design();
            carEngine.Manufacture();
            carEngine.test();

            carTyre.Design();
            carTyre.Manufacture();
            Console.ReadKey();
        }

    }
   
}
