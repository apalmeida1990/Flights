using System.Collections.Generic;
using System.Linq;
using Flights.DAL.Context;
using Flights.Domain.Entity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Flights.Migrations.SeedData
{
    /// <summary>
    /// This class allows insert data in Airport table
    /// </summary>
    public class Seed
    {
        /// <summary> 
        /// Method that reads from file all airports and saves in appropriate table.
        /// </summary> 
        /// <param name="FlightContext">EntityFramework Flights Context</param> 
        public static void SeedAirports(FlightContext context, ILogger logger)
        {
            if (!context.Airports.Any())
            {
                var airportData = System.IO.File.ReadAllText("Migrations/SeedData/airports.json");
                var airports = JsonConvert.DeserializeObject<IList<Airport>>(airportData);
                context.AddRange(airports);
                context.SaveChanges();
            }
        }
    }
}