using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace observer_design_pattern
{
    internal interface ITicketObserver
    {
        void Update(Ticket ticket);
    }
}
