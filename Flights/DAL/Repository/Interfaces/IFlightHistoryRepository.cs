using System.Linq;
using Flights.Domain.Entity;
using Flights.EventLogging.Models;

namespace Flights.DAL.Repository.Interfaces
{
    /// <summary>
    /// Interface for Flight History Repository access. 
    /// At this time is empty.
    /// Could be used to add specific Flight History related actions (eg: Get All Changes made yesterday)
    /// </summary>
    public interface IFlightHistoryRepository : IRepository<FlightHistory>
    {
    }
}