
using Flights.Domain.Entity;
using Flights.EventLogging.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Flights.DAL.Context
{
    //DbSets will be taken in consideration on Initial Migration
    public class FlightContext : DbContext
    {
        // Empty constructor for Entity Framework
        public FlightContext() { }

        public FlightContext(DbContextOptions<FlightContext> options) : base(options){}
        
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }

        public DbSet<FlightHistory> FlightHistory { get; set; }

    }
}