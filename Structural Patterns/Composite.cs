using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Composite pattern - used to represent part whole hierarchies.
//Lets clients to treat individual objects and composite of objects uniformly.
namespace DesignPatterns.Structural_Patterns
{
    public interface BoxItem {
        void print(int level);
    }
    //Leaf
    public class product : BoxItem
    {
        private int id;
        public product(int id)
        {
            this.id = id;
        }
        public void print(int level)
        {
            for(int i=0;i<level;i++)
                Console.Write(" ");
            Console.WriteLine("Product : "+id);
        }
    }
    //composite
    class Box : BoxItem
    {
        private int id;
        private List<BoxItem> items = new List<BoxItem>();
        public Box(int id)
        {
            this.id = id;
        }
        public void print(int level)
        {
            for (int i = 0; i < level; i++)
                Console.Write(" ");
            Console.WriteLine("Box : " + id);
            foreach(BoxItem item in items)
            {
                item.print(level + 1);
            }
        }
        public void addItem(BoxItem item)
        {
            items.Add(item);
        }
        public void removeItem(BoxItem item)
        {
            items.Remove(item);
        }
    }
    public class CompositeClient
    {
        public static void Main(string[] args)
        {
            Box box1 = new Box(2);
            box1.addItem(new product(3));
            box1.addItem(new product(4));
            box1.addItem(new product(5));
            Box box2 = new Box(1);
            box2.addItem(new product(1));
            box2.addItem(new product(2));
            box2.addItem(box1);
            box2.print(0);
            Console.ReadKey();
        }
    }
}
