using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;

namespace DataAccessEF.TypeRepository
{
    public class FlightRepository : GenericRepository<Flight>, IFlightRepository
    {
        public FlightRepository(DataContext context) : base(context)
        {

        }
    }
}
