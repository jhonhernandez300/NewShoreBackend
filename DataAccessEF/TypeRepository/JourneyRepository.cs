using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.TypeRepository
{
    public class JourneyRepository : GenericRepository<Journey>, IJourneyRepository
    {
        public JourneyRepository(DataContext context) : base(context)
        {
            
        }
        int IJourneyRepository.SaveJourney(Journey journey)
        {
            context.Journey.Add(journey);
            return context.SaveChanges();
        }
    }
}
