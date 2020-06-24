using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Mediator pattern - define an object to handle communication between objects called collegues.
//This enables loose coupling between the objects.
namespace DesignPatterns.Behavioral_Patterns
{
	class ATCMediator : IATCMediator
	{
		private Flight flight;
		private Runway runway;
		public bool land;

		public void registerRunway(Runway runway)
		{
			this.runway = runway;
		}

		public void registerFlight(Flight flight)
		{
			this.flight = flight;
		}

		public bool isLandingOk()
		{
			return land;
		}


		public void setLandingStatus(bool status)
		{
			land = status;
		}
	}

	interface GiveCommand
	{
		void land();
	}

	interface IATCMediator
	{

		void registerRunway(Runway runway);

		void registerFlight(Flight flight);

		bool isLandingOk();

		void setLandingStatus(bool status);
	}

	class Flight : GiveCommand
	{
		private IATCMediator atcMediator;

		public Flight(IATCMediator atcMediator)
		{
			this.atcMediator = atcMediator;
		}

		public void land()
		{
			if (atcMediator.isLandingOk())
			{
				Console.WriteLine("Successfully Landed.");
				atcMediator.setLandingStatus(true);
			}
			else
				Console.WriteLine("Waiting for landing.");
		}

		public void getReady()
		{
			Console.WriteLine("Ready for landing.");
		}

	}

	class Runway : GiveCommand
	{
		private IATCMediator atcMediator;

		public Runway(IATCMediator atcMediator)
		{
			this.atcMediator = atcMediator;
			atcMediator.setLandingStatus(true);
		}


		public void land()
		{
			Console.WriteLine("Landing permission granted.");
			atcMediator.setLandingStatus(true);
		}

	}

	class MediatorClient
	{
		public static void Main(String []args)
		{

			IATCMediator atcMediator = new ATCMediator();
			Flight sparrow101 = new Flight(atcMediator);
			Runway mainRunway = new Runway(atcMediator);
			atcMediator.registerFlight(sparrow101);
			atcMediator.registerRunway(mainRunway);
			sparrow101.getReady();
			mainRunway.land();
			sparrow101.land();
			Console.ReadKey();
		}
	} 
}


