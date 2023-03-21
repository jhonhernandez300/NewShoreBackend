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
    public class JourneyFlightRepository : GenericRepository<JourneyFlightRepository>, IJourneyFlightRepository
    {
        public JourneyFlightRepository(DataContext context) : base(context)
        {

        }

        public void Add(JourneyFlight entity)
        {
            context.JourneyFlight.Add(entity);
            context.SaveChanges();
        }

        public IEnumerable<JourneyFlight> Find(Expression<Func<JourneyFlight, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Remove(JourneyFlight entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<JourneyFlight> IGenericRepository<JourneyFlight>.GetAll()
        {
            throw new NotImplementedException();
        }

        JourneyFlight IGenericRepository<JourneyFlight>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        int IJourneyFlightRepository.SaveJourneyFlight(JourneyFlight journeyFlight)
        {
            context.JourneyFlight.Add(journeyFlight);
            return context.SaveChanges();
        }
    }
}
