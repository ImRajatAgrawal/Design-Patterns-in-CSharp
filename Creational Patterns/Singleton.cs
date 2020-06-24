using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

/*Singleton design pattern - restrict the instantiation of more than one object*/
/*Problems Covered - Thread Synchronization*/
namespace DesignPatterns
{
    class Singleton
    {

        private static Singleton instance;
        private Singleton()
        {
        }
        public static Singleton getInstance() {
            //Allows only one thread to access this block of code
            lock (instance)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
            }
            return instance;
        }
    }
}
