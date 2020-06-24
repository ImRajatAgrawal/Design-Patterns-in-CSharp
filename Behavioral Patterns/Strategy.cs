using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Strategy pattern- To support different varients of the algorithm that vary from client to client.
namespace DesignPatterns.Behavioral_Patterns
{
    public interface PaymentStrategy
    {
        void pay();
    }

    public class CashPayment : PaymentStrategy
    {
        private double amount;
        public CashPayment(double amount)
        {
            this.amount = amount;
        }

        public void pay()
        {
            Console.WriteLine("Total Amount : "+this.amount);
        }
    }

    public class CardPayment : PaymentStrategy
    {
        private double amount;
        private string cardType;
        private string issuer;
        public CardPayment(double amount,string cardType,string issuer)
        {
            this.amount = amount;
            this.cardType = cardType;
            this.issuer = issuer;
        }

        public void pay()
        {
            Console.WriteLine("Card Type :"+this.cardType+"\nIssuer Name :"+this.issuer+"\nTotal Amount : " + this.amount);
        }
    }
    public class Item
    {
        public string name { get; set; }
        public double price { get; set; }
        public Item(string name,double price)
        {
            this.name = name;
            this.price = price;
        }

    }
    public class OrderItems
    {
        List<Item> cart;
        List<PaymentStrategy> Payments;
        public OrderItems()
        {
            cart = new List<Item>();
            Payments = new List<PaymentStrategy>();
        }
        public void addItem(Item item)
        {
            cart.Add(item);
            Console.WriteLine("Item Name :"+item.name+" Price: "+item.price);
        }
        public List<Item> getCart() {
            return this.cart;
        }
        public void makePayment(PaymentStrategy payment)
        {
            Payments.Add(payment);
            payment.pay();

        }

    }
    public class StrategyClient
    {
        public static void Main(string[] args)
        {
            OrderItems order = new OrderItems();
            order.addItem(new Item("Pizza",60.50));
            order.addItem(new Item("Burger",30.50));
            order.makePayment(new CashPayment(60.50));
            order.makePayment(new CardPayment(30.50,"Debit","BNY"));
            Console.ReadKey();

        }
    }
}

