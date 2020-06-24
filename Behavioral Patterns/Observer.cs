using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Observer pattern - To notify about the changes to an object state and update all its dependents automatically.
namespace DesignPatterns.Behavioral_Patterns
{
    public interface Subject
    {

        void registerObserver(Observer observer);
        void unRegisterObserver(Observer observer);
        void notifyObservers();
    }

    public class CricketData : Subject
    {
        private int runs;
        private int wickets;
        private float overs;
        private List<Observer> observers;

        public CricketData()
        {
            observers = new List<Observer>();
        }
        public void notifyObservers()
        {
            foreach(var ob in observers)
            {
                ob.update(runs,wickets,overs);
            }
        }

        public void registerObserver(Observer observer)
        {
            observers.Add(observer);
        }

        public void unRegisterObserver(Observer observer)
        {
            observers.Remove(observer);
        }
        private int getLatestRuns()
        {
            // return 90 for simplicity 
            return 90;
        }

        // get latest wickets from stadium 
        private int getLatestWickets()
        {
            // return 2 for simplicity 
            return 2;
        }

        // get latest overs from stadium 
        private float getLatestOvers()
        {
            // return 90 for simplicity 
            return (float)10.2;
        }

        // This method is used update displays 
        // when data changes 
        public void dataChanged()
        {
            //get latest data 
            runs = getLatestRuns();
            wickets = getLatestWickets();
            overs = getLatestOvers();
            notifyObservers();
        }
    }


    public interface Observer
    {
        void update(int runs,int wickets,float overs);
    }

    class AverageScoreDisplay: Observer
    {
        private float runRate;
        private int predictedScore;

        public void update(int runs, int wickets,
                       float overs)
        {
            this.runRate = (float)runs / overs;
            this.predictedScore = (int)(this.runRate * 50);
            display();
        }

        public void display()
        {
                Console.WriteLine("\nAverage Score Display: \n"
                               + "Run Rate: " + runRate +
                               "\nPredictedScore: " +
                               predictedScore);
        }
}

class CurrentScoreDisplay : Observer
{
    private int runs, wickets;
    private float overs;

    public void update(int runs, int wickets,
                       float overs)
    {
        this.runs = runs;
        this.wickets = wickets;
        this.overs = overs;
        display();
    }

    public void display()
    {
            Console.WriteLine("\nCurrent Score Display:\n"
                           + "Runs: " + runs +
                           "\nWickets:" + wickets +
                           "\nOvers: " + overs);
    } 
} 


    class ObserverClient
    {
        public static void Main(string[] args)
        {
            AverageScoreDisplay averageScoreDisplay =
                          new AverageScoreDisplay();
            CurrentScoreDisplay currentScoreDisplay =
                              new CurrentScoreDisplay();

            // pass the displays to Cricket data 
            CricketData cricketData = new CricketData();

            // register display elements 
            cricketData.registerObserver(averageScoreDisplay);
            cricketData.registerObserver(currentScoreDisplay);

            // in real app you would have some logic to 
            // call this function when data changes 
            cricketData.dataChanged();

            //remove an observer 
            cricketData.unRegisterObserver(averageScoreDisplay);

            // now only currentScoreDisplay gets the 
            // notification 
            cricketData.dataChanged();
            Console.ReadKey();
        }
    }
}
