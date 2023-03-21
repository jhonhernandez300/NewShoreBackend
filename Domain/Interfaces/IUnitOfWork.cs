using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITransportRepository Transport { get; }

        IJourneyRepository Journey { get; }

        IFlightRepository Flight { get; }

        IJourneyFlightRepository JourneyFlight { get; }

        int Save();
    }
}
