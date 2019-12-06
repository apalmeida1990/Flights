using System.Linq;
using Flights.Domain.Entity;

namespace Flights.DAL.Repository.Interfaces
{
    /// <summary>
    /// Interface for Flight Repository access. 
    /// At this time is empty.
    /// Could be used to add specific Flight related actions (eg: Get all Flight with departure from a specific airport)
    /// </summary>
    public interface IFlightRepository : IRepository<Flight>
    {
    }
}