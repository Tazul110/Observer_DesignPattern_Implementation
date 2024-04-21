using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer_design_pattern
{
    internal class Ticket
    {
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal Price { get; set; }
    }
}
