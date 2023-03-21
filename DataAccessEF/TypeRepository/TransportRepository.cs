using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.TypeRepository
{
    public class TransportRepository : GenericRepository<Transport>, ITransportRepository
    {
        public TransportRepository(DataContext context) : base(context)
        {

        }
    }
}
