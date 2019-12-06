using System;

namespace Flights.Models
{
    public class FlightHistoryViewModel
    {
        public Guid EventId { get; set; }
        public Guid EntityId { get; set; }
        public string DepartureAirportCode { get; set; }
        public string DepartureAirportName { get; set; }
        public string DestinationAirportCode { get; set; }
        public string DestinationAirportName { get; set; }
        public double FlightTime { get; set; }
        public double Distance { get; set; }
        public double FuelNeeded { get; set; }
        public double TakeOffEffort { get; set; }
        public string Action { get; set; }
        public DateTime ActionDate { get; set; }
    }
}