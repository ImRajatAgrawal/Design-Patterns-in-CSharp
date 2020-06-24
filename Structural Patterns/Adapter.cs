using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Adapter pattern - allows incompatible interfaces to interact
// acts as a bridge between the adaptee and the target interface that the client wants
//Two types - Object Adapter(uses composition) and class Adapter(uses inheritance) 
//below is the example of object adapter for Order Management System
namespace DesignPatterns.Structural_Patterns
{
    public class MenuItem
    {
        public string name { get; set; }
        public double price { get; set; }
        public MenuItem(string name,double price)
        {
            this.name = name;
            this.price = price;
        }
    }
    public class Payment
    {
        public string type { get; set; }
        public double amount { get; set; }
        public Payment(string type,double amount)
        {
            this.type = type;
            this.amount = amount;
        }
        public void pay()
        {
            Console.WriteLine("Payment Type : "+type+" "+"Amount : "+amount);
        }
    }

    public class NewOMS {
        private List<MenuItem> cart;
        private List<Payment> payments;
        public NewOMS()
        {
            cart = new List<MenuItem>();
            payments = new List<Payment>();
        }
        public void addToBasket(MenuItem item)
        {
            cart.Add(item);
            Console.WriteLine("Item Name: "+item.name+" Price : "+item.price);
        }
        public void makePayment(Payment payment) {
            payments.Add(payment);
            payment.pay();
        }
    }
    class OMSAdapter
    {
        private NewOMS newOMS;
        public OMSAdapter()
        {
            newOMS = new NewOMS();
        }
        public void addItem(MenuItem item)
        {
            convertXmlToJson(item);
            newOMS.addToBasket(item);
        }
        public void makePayment(Payment payment)
        {
            convertXmlToJson(payment);
            newOMS.makePayment(payment);
        }
        public void convertXmlToJson(Object obj){
            Console.WriteLine("Converted from xml to JSON");
        }
    }

    public class OMSClient
    {
        public static void Main(string[] args)
        {
            OMSAdapter adapter = new OMSAdapter();
            adapter.addItem(new MenuItem("Pizza",600));
            adapter.addItem(new MenuItem("Burger",100));
            adapter.makePayment(new Payment("credit card",700));
            Console.ReadKey();
        }
    }
}
