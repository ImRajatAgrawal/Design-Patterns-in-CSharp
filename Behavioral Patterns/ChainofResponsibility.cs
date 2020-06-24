using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Chain of Responsibility pattern - used to process request by multiple objects until the request is handled by an object.
namespace DesignPatterns.Behavioral_Patterns
{
    public class Cashdispenser
    {
        private Cashdispenser next;
        private int denominator;
        public Cashdispenser(int val)
        {
            next = null;
            denominator = val;
        }
        public void setNextDispenser(Cashdispenser dispenser)
        {
            if (this.next == null)
            {
                this.next = dispenser;
            }
            else
               this.next.setNextDispenser(dispenser);
        }
        public void Dispense(int amount)
        {
            if (amount >= denominator)
            {
                int num = amount / denominator;
                int balance = amount % denominator;
                Console.WriteLine(num + " * " + denominator);
                if (balance != 0)
                    next.Dispense(balance);

            }
            else
            {
                if (amount != 0)
                    next.Dispense(amount);
            }
        }
    }

    class ChainofResponsibilityClient
    {
        public static void Main(string[] args)
        {
            Cashdispenser cd = new Cashdispenser(2000);
            cd.setNextDispenser(new Cashdispenser(500));
            cd.setNextDispenser(new Cashdispenser(200));
            cd.setNextDispenser(new Cashdispenser(100));
            cd.setNextDispenser(new Cashdispenser(50));
            cd.setNextDispenser(new Cashdispenser(20));
            cd.setNextDispenser(new Cashdispenser(10));
            cd.setNextDispenser(new Cashdispenser(5));
            cd.setNextDispenser(new Cashdispenser(2));
            cd.setNextDispenser(new Cashdispenser(1));

            cd.Dispense(523418);
            Console.ReadKey();
        }
    }
}
