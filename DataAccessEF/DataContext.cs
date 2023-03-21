using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccessEF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Flight> Flight { get; set; }
        public DbSet<Journey> Journey { get; set; }
        public DbSet<Transport> Transport { get; set; }
        public DbSet<JourneyFlight> JourneyFlight { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasKey(m => m.FlightId);

            modelBuilder.Entity<Journey>().HasKey(m => m.JourneyId);

            modelBuilder.Entity<Transport>().HasKey(m => m.TransportId);

            //modelBuilder.Entity<JourneyFlight>().HasKey(m => m.JourneyFlightId);
            modelBuilder.Entity<JourneyFlight>()
                .HasKey(m => new { m.JourneyId, m.FlightId });

            modelBuilder.Entity<JourneyFlight>()
          .HasOne(p => p.Flight)
          .WithMany(b => b.JourneyFlights)
          .HasForeignKey(t => t.FlightId);

            modelBuilder.Entity<JourneyFlight>()
           .HasOne(p => p.Journey)
           .WithMany(b => b.JourneyFlights)
           .HasForeignKey(t => t.JourneyId);

            modelBuilder.Entity<Flight>()
           .HasOne(p => p.Transport)
           .WithMany(b => b.Flights)
           .HasForeignKey(t => t.TransportId);
        }
    }
}
