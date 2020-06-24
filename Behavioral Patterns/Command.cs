using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral_Patterns
{
    //Command pattern - used to process or execute multiple commands after a specific command is executed.
    //decouples the object that invokes the operation from the object that performs the implementation.
    public class MainDish
    {
        string name;
        public MainDish(string name)
        {
            this.name = name;
        }
        public void order()
        {
            Console.WriteLine("Main Dish ( " + name + " ) is ordered");
        }
        public void cancel()
        {
            Console.WriteLine("Main Dish ( " + name + " ) is cancelled");
        }
    }
    public class Desert
    {
        string name;
        public Desert(string name)
        {
            this.name = name;
        }
        public void order()
        {
            Console.WriteLine("Desert ( " + name + " ) is ordered");
        }
        public void cancel()
        {
            Console.WriteLine("Desert ( " + name + " ) is cancelled");
        }
    }
    public interface Command
    {
        void execute();
        void undo();
    }
    public class OrderCancelMainDish : Command
    {
        MainDish mainDish;
        public OrderCancelMainDish(MainDish item)
        {
            mainDish = item;
        }
        public void execute()
        {
            mainDish.order();
        }

        public void undo()
        {
            mainDish.cancel();
        }
    }
    public class OrderCancelDesert : Command
    {
        Desert desert;
        public OrderCancelDesert(Desert item)
        {
            desert = item;
        }
        public void execute()
        {
            desert.order();
        }

        public void undo()
        {
            desert.cancel();
        }
    }
    public class Waiter
    {
        
       

        public void order(Command command) {
            command.execute();
        }
        public void cancel(Command command)
        {
            command.undo();
        }
    }
    class CommandClient
    {
        public static void Main(string[] args)
        {
            MainDish mainDish = new MainDish("Pizza");
            Desert desert = new Desert("Icecream");
            Waiter waiter = new Waiter();
            waiter.order(new OrderCancelMainDish(mainDish));
            OrderCancelDesert command1 = new OrderCancelDesert(desert);
            waiter.order(command1);
            waiter.cancel(command1);
            Console.ReadKey();
        }
    }
}
