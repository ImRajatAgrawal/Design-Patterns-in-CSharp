using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Visitor Pattern - helps to define a new operation without 
//changing the class of the elements on which operates.
namespace DesignPatterns.Behavioral_Patterns
{

    public interface Visitable
    {
        void apply(Visitor visitor);
    }
    public class FoodItem : Visitable
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }

        public FoodItem(int id,string name,double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
        public void apply(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
    public class LiquorItem : Visitable
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }

        public LiquorItem(int id, string name, double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
        public void apply(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
    public interface Visitor
    {
        void visit(FoodItem item);
        void visit(LiquorItem item);
    }
    public class DiscountVisitor : Visitor
    {
        private double totalDiscount;
        public void visit(FoodItem item)
        {
            double discount = item.price * 0.03;
            totalDiscount += discount;
            item.price = item.price - discount;
        }

        public void visit(LiquorItem item)
        {
            double discount = item.price * 0.1;
            totalDiscount += discount;
            item.price = item.price - discount;
        }
        public double getTotalDiscount()
        {
            return totalDiscount;
        }
    }
    public class VisitorClient
    {
        public static void Main(string[] args)
        {
            DiscountVisitor discountVisitor = new DiscountVisitor();

            List<Visitable> order = new List<Visitable>()
             {
                new FoodItem(1,"Pizza",600),
                new LiquorItem(1,"Wine",600),
                new FoodItem(2,"Burger",60)


            };
            foreach(var item in order)
            {
                item.apply(discountVisitor);
            }
            Console.WriteLine("Total Discount : "+discountVisitor.getTotalDiscount());
            Console.ReadKey();
        }
    }
}
