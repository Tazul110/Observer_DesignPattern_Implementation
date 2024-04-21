using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer_design_pattern
{
    internal class TicketBookingSystem : ITicketBookingSystem
    {
        private Dictionary<string, List<ITicketObserver>> observers;

        //private Dictionary<string, List<IObserver>> observers;
        private List<Ticket> availableTickets;

        public TicketBookingSystem()
        {
            observers = new Dictionary<string, List<ITicketObserver>>();
            //observers = new List<ITicketObserver>();
            availableTickets = new List<Ticket>();
        }

        public void RegisterObserver(ITicketObserver observer,string @event)
        {
            if (!observers.ContainsKey(@event))
            {
                observers[@event] = new List<ITicketObserver>();
            }
            observers[@event].Add(observer);
        }

        public void RemoveObserver(ITicketObserver observer, string @event)
        {
            if (observers.ContainsKey(@event))
            {
                observers[@event].Remove(observer);
                if (observers[@event].Count == 0)
                {
                    observers.Remove(@event);
                }
            }
        }

        public void NotifyObservers( Ticket ticket, string @event)
        {
            if (observers.ContainsKey(@event))
            {
                foreach (var observer in observers[@event])
                {
                    observer.Update(ticket);
                }
            }
        }

        public void AddTicket(Ticket ticket)
        {
            availableTickets.Add(ticket);
            /*NotifyObservers(ticket);*/
        }

        public void RemoveTicket(Ticket ticket)
        {
            availableTickets.Remove(ticket);
        }

        
    }
}
