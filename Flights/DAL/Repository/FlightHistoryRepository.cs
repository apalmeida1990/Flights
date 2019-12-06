using Flights.DAL.Context;
using Flights.DAL.Repository.Interfaces;
using Flights.Domain.Entity;
using Flights.EventLogging.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Flights.DAL.Repository
{
    /// <summary>
    /// Implementation IFlightHistoryRepository
    /// </summary>
    public class FlightHistoryRepository : Repository<FlightHistory>, IFlightHistoryRepository
    {
        public FlightHistoryRepository(FlightContext context) : base(context)
        {
        }
    }
}