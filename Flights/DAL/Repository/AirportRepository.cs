using Flights.DAL.Context;
using Flights.DAL.Repository.Interfaces;
using Flights.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Flights.DAL.Repository
{
    /// <summary>
    /// Implementation IAirportRepository
    /// </summary>
    public class AirportRepository : Repository<Airport>, IAirportRepository
    {
        public AirportRepository(FlightContext context) : base(context)
        {
        }

        public Airport GetByIataCode(string code)
        {
           return _dbSet.AsNoTracking().FirstOrDefault(s => s.Id == code);
        }
    }
}