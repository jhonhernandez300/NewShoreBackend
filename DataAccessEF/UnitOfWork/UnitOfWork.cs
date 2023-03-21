using DataAccessEF.TypeRepository;
using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext context;
        public UnitOfWork(DataContext context)
        {
            this.context = context;
            Flight = new FlightRepository(this.context);
            Journey = new JourneyRepository(this.context);
            Transport = new TransportRepository(this.context);
            JourneyFlight = new JourneyFlightRepository(this.context);
        }

        public IFlightRepository Flight { get; private set; }
        public IJourneyRepository Journey { get; private set; }
        public ITransportRepository Transport { get; private set; }
        public IJourneyFlightRepository JourneyFlight { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
