using System;

namespace Flights.EventLogging.EventNotification
{
    public class UpdateFlightEventLog : EventLog
    {
        public UpdateFlightEventLog()
        {

        }

        public UpdateFlightEventLog(Guid entityId, string departureAirportCode, string departureAirportName, string destinationAirportCode, string destinationAirportName, double flightTime, double distance, double fuelNeeded, double takeOffEffort)
        {
            this.EntityId = entityId;
            this.DepartureAirportCode = departureAirportCode;
            this.DepartureAirportName = departureAirportName;
            this.DestinationAirportCode = destinationAirportCode;
            this.DestinationAirportName = destinationAirportName;
            this.FlightTime = flightTime;
            this.Distance = distance;
            this.FuelNeeded = fuelNeeded;
            this.TakeOffEffort = takeOffEffort;

        }
        public Guid EntityId { get; private set; }
        public string DepartureAirportCode { get; private set; }
        public string DepartureAirportName { get; private set; }
        public string DestinationAirportCode { get; private set; }
        public string DestinationAirportName { get; private set; }
        public double FlightTime { get; private set; }
        public double Distance { get; private set; }
        public double FuelNeeded { get; private set; }
        public double TakeOffEffort { get; private set; }
    }
}