using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Memento pattern - save the internal state of an object so that the object can be restored to its old state later.
namespace DesignPatterns.Behavioral_Patterns
{
    
    public class RecoveryImage
    {
        private string image;
        public RecoveryImage(string image)
        {
            this.image = image;
        }
        public string getSystemImage() {
            return image;
        }
    }

    public class OS
    {
        private StringBuilder installedSW;
        public OS(string OS)
        {
            installedSW = new StringBuilder(OS);
        }
        public void install(string sw)
        {
            installedSW.Append(" + "+sw);
            Console.WriteLine(installedSW);
        }
        public RecoveryImage saveImage()
        {
            Console.WriteLine("Saved OS Image");
            return new RecoveryImage(installedSW.ToString());
        }
        public void restoreImage(RecoveryImage m)
        {
            installedSW= new StringBuilder(m.getSystemImage());
            Console.WriteLine("Restored OS Image");
            Console.WriteLine(installedSW);
        }

    }
    public class RecoveryTool
    {
        private ArrayList mementos = new ArrayList();
        public void addImage(RecoveryImage m)
        {
            mementos.Add(m);
        }
        public void deleteLastImage()
        {
            mementos.RemoveAt(mementos.Count - 1);
        }
        public RecoveryImage getLastGoodImage()
        {
            return (RecoveryImage)mementos.ToArray().GetValue(mementos.Count-1);
        }
    }
    class MementoClient
    {
        public static void Main(string[] args)
        {
            OS os = new OS("Windows 10");
            os.install("Antivirus");
            RecoveryTool tool = new RecoveryTool();
            tool.addImage(os.saveImage());
            os.install("WAMP server");
            tool.addImage(os.saveImage());
            os.install("Mysql");
            //os corrupted
            os.restoreImage(tool.getLastGoodImage());
            //os corrupted again
            tool.deleteLastImage();
            os.restoreImage(tool.getLastGoodImage());
            Console.ReadKey();
        }
    }
}
