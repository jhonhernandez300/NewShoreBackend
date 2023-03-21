using Domain.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccessEF.TypeRepository
{
    public class JourneyFlightRepository : GenericRepositoryJourneyFlight<JourneyFlight>, IJourneyFlightRepository
    {
        public JourneyFlightRepository(DataContext context) : base(context)
        {

        }

        int IJourneyFlightRepository.GetJourneyFlight(JourneyFlight journeyFlight)
        {
            context.JourneyFlight.GetByOriginAndDestination(journeyFlight);
            //return context.SaveChanges();
            return 1;
        }

        int IJourneyFlightRepository.SaveJourneyFlight(JourneyFlight journeyFlight)
        {
            context.JourneyFlight.Add(journeyFlight);
            return context.SaveChanges();
        }
    }
}
