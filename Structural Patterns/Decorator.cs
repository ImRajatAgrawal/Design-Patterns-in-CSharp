using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Decorator pattern - change functionality of an object at runtime instead of creating multiple subclasses
namespace DesignPatterns.Structural_Patterns
{
    public interface Item
    {
        void prepare();
    }
    public class Pizza : Item
    {
        public void prepare()
        {
            Console.Write("Pizza");
        }
    }
    public abstract class PizzaDecorator : Item
    {
        private Item pizza;
        public PizzaDecorator(Item item)
        {
            pizza = item;
        }
        public virtual void prepare()
        {
            pizza.prepare();
        }
    }
    public class DoubleCheese : PizzaDecorator
    {
        public DoubleCheese(Item item):base(item)
        {
            Console.WriteLine("adding cheese");
        }
        public override void prepare()
        {
            base.prepare();
            Console.Write(" + Double Cheese");
        }
    }
    public class Spicy : PizzaDecorator
    {
        public Spicy(Item item) : base(item)
        {
            Console.WriteLine("making spicy");
        }
        public override void prepare()
        {
            base.prepare();
            Console.Write(" + Spicy");
        }
    }
    class DecoratorClient
    {
        public static void Main(string[] args)
        {
            Item[] order =
            {
                new DoubleCheese(new Pizza()),
                new Spicy(new DoubleCheese(new Pizza()))
            };
            foreach (Item item in order){
                item.prepare();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
