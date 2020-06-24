using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
//FlyWeight pattern - used when a system requires a large no of objects to be created.
//Improves the performance by reusing the same objects by applying some extrinsic properties
namespace DesignPatterns.Structural_Patterns
{
    public class RaceVehicle
    {
        private string name;
        private string color;
        private string type;
        private int speed;
        private int duration;
        private const string task="Obstruct the racers";
        private bool active;
        private System.Timers.Timer timer;

        public System.Timers.Timer TimedEvent { get; private set; }

        public RaceVehicle(string name)
        {
            this.name = name;
            active = false;
        }
        public void setProperties(string color,string type,int speed,int duration)
        {
            this.color = color;
            this.speed = speed;
            this.type = type;
            this.duration = duration;
            
        }

        public bool isActive() {
            return this.active;
        }
        public void addTraffic()
        {
            Console.WriteLine("-> "+name+" - "+type+" - "+color+" - "+speed
                +"mph - "+duration+"seconds");

            this.timer = new System.Timers.Timer();
            this.timer.Interval=duration * 5000;
            this.active = true;
            this.timer.AutoReset = false;
            this.timer.Elapsed += TimerEvent;
            this.timer.Enabled = true;
            
        }

        private void TimerEvent(object sender, ElapsedEventArgs e)
        {
            active = false;
            Console.WriteLine(name + "->out");
        }
    }
    public class RaceVehicleFactory
    {
        private List<RaceVehicle> pool;
        public RaceVehicleFactory()
        {
            pool = new List<RaceVehicle>();
            for(int i = 0; i < 5; i++)
            {
                pool.Add(new RaceVehicle("V : "+(i+1)));
            }
        }
        public RaceVehicle getRaceVehicle(string color, string type, int speed, int duration)
        {
            foreach(RaceVehicle v in pool)
            {
                if (!v.isActive())
                {
                    v.setProperties(color, type, speed, duration);
                    return v;
                }
            }
            return null;
        }
    }
    class FlyWeightClient
    {
        static Random r = new Random();
        private static string[] types = { "bus", "car", "truck" };
        private static string[] colors = { "red", "blue", "green"};
        private static int[] speeds = { 20,50,10 };


        public static void Main(string[] args)
        {
            RaceVehicleFactory factory = new RaceVehicleFactory();
            for(int i = 0; i < 20; i++)
            {
                RaceVehicle vehicle = factory.getRaceVehicle(getRandColor(),getRandType(),getRandSpeed(),(r.Next(5)+1));
                if (vehicle != null)
                {
                    Console.WriteLine("Race Vehicle"+(i+1));
                    vehicle.addTraffic();
                }
                else
                {
                    i--;
                    Thread.Sleep(1000);
                }
            }
            Console.ReadKey();
        }
        public static string getRandType()
        {
            return types[r.Next(types.Length)];
        }
        public static string getRandColor()
        {
            return colors[r.Next(colors.Length)];
        }
        public static int getRandSpeed()
        {
            return speeds[r.Next(speeds.Length)];
        }
    }
}
