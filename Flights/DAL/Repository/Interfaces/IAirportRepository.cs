using System.Threading.Tasks;
using Flights.Domain.Entity;

namespace Flights.DAL.Repository.Interfaces
{
    /// <summary>
    /// Interface for Airport Repository access. 
    /// </summary>
    public interface IAirportRepository : IRepository<Airport>
    {
        /// <summary>
        /// Search an Airport by a given Code.
        /// Id from Airport Table is IATA Code.
        /// </summary>
        /// <param name="code">IATA Code from airport</param>
        /// <returns>Airport Entity</returns>
        Airport GetByIataCode(string code);
    }
}