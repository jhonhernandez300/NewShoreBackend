using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Transport
    {
        public Transport()
        {
            Flights = new HashSet<Flight>();
        }
        public int TransportId { get; set; }
        public string? FlightCarrier { get; set; }
        public string? FlightNumber { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
