using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
//Proxy pattern - provides controlled access to a master Object.
//Acts a a gateway between your computer and the internet.
//uses for security purposes
namespace DesignPatterns.Structural_Patterns
{

    public interface Server
    {
        void authenticate();
        void get();
        void post();
        void put();
        void logout();
        
    }
    public class RealServer : Server
    {
        public void authenticate()
        {
            Console.WriteLine("Logged into the real server");
        }

        public void get()
        {
            Console.WriteLine("get request executed");
        }

        public void logout()
        {
            Console.WriteLine("Logged out fromm real serverr");
        }

        public void post()
        {
            Console.WriteLine("post request executed");
        }

        public void put()
        {
            Console.WriteLine("put request executed");
        }
        public void delete()
        {
            Console.WriteLine("delete request made by admin of the real server");
        } 
    }
    class ProxyServer : Server
    {
        private RealServer realServer;
        private bool sessionActive;
        public ProxyServer()
        {
            realServer = new RealServer();
            sessionActive = false;
        }
        public void authenticate()
        {
            realServer.authenticate();
            sessionActive = true;
        }

        public void get()
        {
            if (sessionActive)
                realServer.get();
            else
                Console.WriteLine("Invalid Session");
        }

        public void logout()
        {
            realServer.logout();
            sessionActive = false;
        }

        public void post()
        {
            if (sessionActive)
                realServer.post();
            else
                Console.WriteLine("Invalid Session");
        }

        public void put()
        {
            if (sessionActive)
                realServer.put();
            else
                Console.WriteLine("Invalid Session");
        }
    }
    public class ProxyClient
    {
        public static void Main(string[] args)
        {
            Server proxyserver = new ProxyServer();
            proxyserver.authenticate();
            proxyserver.get();
            proxyserver.post();
            proxyserver.put();
            proxyserver.logout();

            Server realserver = new RealServer();
            //realserver.delete(); Access to this method is denied as delete can only be performed by admin

        }
    }
}
