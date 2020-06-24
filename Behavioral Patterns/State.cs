using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//State pattern - an object should alter its behavior when its state change i.e it should change its class.
namespace DesignPatterns.Behavioral_Patterns
{

    public interface AtmState
    {
        void withdraw(int amount);
        void refill(int amount);
    }
    public class working : AtmState
    {
        Atm atm;
        public working(Atm atm)
        {
            this.atm = atm;
        }
        public void refill(int amount)
        {
            atm.cashStock = atm.cashStock + amount;
            Console.WriteLine("Rs."+amount+" is loaded");
        }

        public void withdraw(int amount)
        {
            int cashStock = atm.cashStock;
            if (amount > cashStock)
            {
                amount = cashStock;
                Console.WriteLine("Partial Amount");
            }
            Console.WriteLine("Rs."+amount+" is dispensed");
            int newCashStock = cashStock-amount;
            atm.cashStock = newCashStock;
            if (newCashStock == 0)
                atm.currentState = new NoCash(atm);
            
        }
    }
    public class NoCash : AtmState
    {
        Atm atm;
        public NoCash(Atm atm)
        {
            this.atm = atm;
        }
        public void refill(int amount)
        {
            atm.cashStock = atm.cashStock+amount;
            atm.currentState = new working(atm);
        }

        public void withdraw(int amount)
        {
            Console.WriteLine("Machine Out of Cash");

        }
    }
    public class Atm : AtmState
    {
        public int cashStock { get; set; }
        public AtmState currentState { get; set; }
        public Atm()
        {
            currentState = new NoCash(this);
        }
        public void refill(int amount)
        {
            currentState.refill(amount);   
        }

        public void withdraw(int amount)
        {
            currentState.withdraw(amount);
        }
    }
    class StateClient
    {
        public static void Main(string[] args)
        {
            Atm atm = new Atm();
            atm.refill(100);
            atm.withdraw(50);
            atm.withdraw(30);
            atm.withdraw(30);
            atm.withdraw(20);
            atm.refill(50);
            atm.refill(50);
            atm.withdraw(50);
            Console.ReadKey();
        }
    }
}
