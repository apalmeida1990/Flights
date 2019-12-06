using Flights.DAL.Context;
using Flights.DAL.Repository.Interfaces;
using Flights.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Flights.DAL.Repository
{
    /// <summary>
    /// Implementation IFlightRepository
    /// </summary>
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        public FlightRepository(FlightContext context) : base(context)
        {
        }
    }
}