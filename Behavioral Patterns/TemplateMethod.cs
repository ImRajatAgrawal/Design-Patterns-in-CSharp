using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Template Method pattern - To define a skeleton of an algorithm or an operation.
//Allow the subclasses to redefine part of the logic but not the structure of the algorithm.
namespace DesignPatterns.Behavioral_Patterns
{
    //Template method class
    
    public abstract class Pizza
    {
        public void preparePizza() {
            selectCrust();
            addIngredients();
            addToppings();
            cook();
        }
        public virtual void selectCrust() {
            Console.WriteLine("Selecting default Crust");
        }
        public virtual void cook()
        {
            Console.WriteLine("Cook for 5 minutes");
        }
        public abstract void addIngredients();
        public abstract void addToppings();
        
    }
    public class CheesePizza : Pizza
    {
      
        public override void addIngredients()
        {
            Console.WriteLine("Add cheese");
        }

        public override void addToppings()
        {
            Console.WriteLine("Add veggies");
        }
        public override void cook()
        {
            Console.WriteLine("cook for 10 minutes");
        }
    }


    class TemplateMethodClient
    {
        public static void Main(string[] args)
        {
            Pizza cheesePizza = new CheesePizza();
            cheesePizza.preparePizza();
            Console.ReadKey();
        }
    }
}
