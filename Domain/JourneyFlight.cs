using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class JourneyFlight
    {
        //public int JourneyFlightId { get; set; }
        public int JourneyId { get; set; }
        public Journey? Journey { get; set; }
        public int FlightId { get; set; }
        public Flight? Flight { get; set; }
    }
}
