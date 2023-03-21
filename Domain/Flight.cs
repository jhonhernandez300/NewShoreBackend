using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain
{
    public class Flight
    {
        public Flight()
        {
            JourneyFlights = new HashSet<JourneyFlight>();
        }
        public int FlightId { get; set; }
        public string? FlightOrigin { get; set; }
        public string? FlightDestination { get; set; }
        public double? FlightPrice { get; set; }
        public virtual ICollection<JourneyFlight> JourneyFlights { get; set; }

        public int TransportId { get; set; }
        public Transport? Transport { get; set; }
    }
}
