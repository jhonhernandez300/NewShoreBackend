using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Journey
    {
        public Journey()
        {
            JourneyFlights = new HashSet<JourneyFlight>();
        }
        public int JourneyId { get; set; }
        public string JourneyOrigin { get; set; }
        public string JourneyDestination { get; set; }
        public double JourneyPrice { get; set; }

        public virtual ICollection<JourneyFlight> JourneyFlights { get; set; }
    }
}
