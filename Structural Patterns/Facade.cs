using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Facade pattern - hide the complexity of the system from the client by providing a simplified interface
namespace DesignPatterns.Structural_Patterns
{
    public class Hall
    {
        public void book()
        {
            Console.WriteLine("Book Marriage Hall");
        }
    }
    public class Restaurant
    {
        public void placeorder()
        {
            Console.WriteLine("order food");
        }
    }
    public class Photographer
    {
        public void Hire()
        {
            Console.WriteLine("Hire Photographer");
        }
    }
    public class Vehicle
    {
        public void reserve()
        {
            Console.WriteLine("reserve a car");
        }
    }


    class WeddingPlannerFacade
    {
        private Hall hall;
        private Restaurant restaurant;
        private Photographer photographer;
        private Vehicle vehicle;

        public WeddingPlannerFacade()
        {
            hall = new Hall();
            restaurant = new Restaurant();
            photographer = new Photographer();
            vehicle = new Vehicle();
        }
        public void organize(){
            hall.book();
            restaurant.placeorder();
            photographer.Hire();
            vehicle.reserve();
        }
        
            
    }
}
