using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer_design_pattern
{
    internal class User : ITicketObserver
    {
        public void Update( Ticket ticket)
        {
            Console.WriteLine($" New ticket available to {ticket.Destination} departing at {ticket.DepartureTime}, Price: {ticket.Price}");
        }
    }
}