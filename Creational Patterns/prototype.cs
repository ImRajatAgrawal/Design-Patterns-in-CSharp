using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//prototype pattern - create objects by cloning other objects.
//Avoid creation of objects with new operator
//Application - cloud machine create multiple instances
namespace DesignPatterns
{
    public class MachineImage: ICloneable
    {
        private StringBuilder image;
        public MachineImage(string machinename,string antivirus)
        {
            image = new StringBuilder();
            image.Append(machinename);
            image.Append(" + "+antivirus);

        }
        private MachineImage(string image)
        {
            this.image = new StringBuilder(image);
        }

        public object Clone()
        {
            return new MachineImage(this.image.ToString());
        }

        public void install(string software)
        {
            image.Append(software);
        }
        public string MachineDetails() {
            return this.image.ToString();
        }
       
    }
    public class PrototypeClient
    {
        public static void Main(string[] args)
        {
            MachineImage linuxVM = new MachineImage("Linux","Norton");
            MachineImage WindowsVM = new MachineImage("Windows","Mcafee");

            MachineImage WebServer = (MachineImage)linuxVM.Clone();
            WebServer.install("+ Webserver");
            Console.WriteLine(WebServer.MachineDetails());
            Console.ReadKey();
        }
    }
}
