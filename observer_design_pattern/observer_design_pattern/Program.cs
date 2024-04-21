using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer_design_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a ticket booking system
        TicketBookingSystem ticketBookingSystem = new TicketBookingSystem();

        // Create displays
        //OnlineTicketDisplay onlineDisplay = new OnlineTicketDisplay();
        //MobileAppDisplay mobileDisplay = new MobileAppDisplay();

            User u1 = new User();
            User u2 = new User();
            User u3 = new User();


            // Register displays as observers
            ticketBookingSystem.RegisterObserver(u1, "event1");
            ticketBookingSystem.RegisterObserver(u2, "event2");
            ticketBookingSystem.RegisterObserver(u3, "event1");

            // Add some tickets
            Ticket ticket1 = new Ticket { Destination = "New York", DepartureTime = DateTime.Now.AddDays(7), Price = 300 };
            Ticket ticket2 = new Ticket { Destination = "Los Angeles", DepartureTime = DateTime.Now.AddDays(14), Price = 250 };


            ticketBookingSystem.AddTicket(ticket1);
            ticketBookingSystem.AddTicket(ticket2);

            ticketBookingSystem.NotifyObservers( ticket1, "event2");

            // Remove a ticket
            ticketBookingSystem.RemoveTicket(ticket1);

        Console.ReadLine();
        }
    }
}
