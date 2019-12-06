using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flights.EventLogging.Models
{
    public class FlightHistory
    {
        [Key]
        public Guid EventId { get; private set; }
        public Guid EntityId { get; private set; }
        public string DepartureAirportCode { get; private set; }
        public string DepartureAirportName { get; private set; }
        public string DestinationAirportCode { get; private set; }
        public string DestinationAirportName { get; private set; }
        public double FlightTime { get; private set; }
        public double Distance { get; private set; }
        public double FuelNeeded { get; private set; }
        public double TakeOffEffort { get; private set; }
        public string Action { get; private set; }
        public DateTime ActionDate { get; private set; }
    }
}