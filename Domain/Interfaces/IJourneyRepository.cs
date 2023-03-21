using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IJourneyRepository : IGenericRepository<Journey>
    {
       int SaveJourney(Journey journey);
    }
}
