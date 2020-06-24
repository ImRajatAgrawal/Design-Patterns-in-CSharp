
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton instance1 = Singleton.getInstance();
            Console.WriteLine( instance1.GetHashCode());
            Singleton instance2 = Singleton.getInstance();
            Console.WriteLine(instance2.GetHashCode());
            Console.ReadKey();
        }
    }
}
