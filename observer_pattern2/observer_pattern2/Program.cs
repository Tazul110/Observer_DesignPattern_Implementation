using System;
using System.Collections.Generic;

namespace observer_pattern2
{
    public interface ITicketObserver
    {
        void Update(Ticket ticket);
    }

    public class OnlineTicketDisplay : ITicketObserver
    {
        private List<string> displayTypes;

        public OnlineTicketDisplay(List<string> displayTypes)
        {
            this.displayTypes = displayTypes;
        }

        public void Update(Ticket ticket)
        {
            foreach (var displayType in displayTypes)
            {
                Console.WriteLine($"{displayType}: New ticket available to {ticket.Destination} departing at {ticket.DepartureTime}, Price: {ticket.Price}");
            }
        }
    }

    public class TicketDisplayManager
    {
        private List<ITicketObserver> observers;

        public TicketDisplayManager()
        {
            observers = new List<ITicketObserver>();
        }

        public void RegisterObserver(ITicketObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(ITicketObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(Ticket ticket)
        {
            foreach (var observer in observers)
            {
                observer.Update(ticket);
            }
        }
    }

    public class Ticket
    {
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal Price { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> displayTypes = new List<string> { "Online Ticket Display", "Mobile App Display" };

            TicketDisplayManager displayManager = new TicketDisplayManager();
            OnlineTicketDisplay onlineDisplay = new OnlineTicketDisplay(displayTypes);

            displayManager.RegisterObserver(onlineDisplay);

            Ticket ticket = new Ticket { Destination = "New York", DepartureTime = DateTime.Now.AddDays(7), Price = 300 };

            displayManager.NotifyObservers(ticket);

            Console.ReadLine();
        }
    }
}
