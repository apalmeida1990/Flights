using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flights.Domain.Entity
{
    public class Flight
    {
        public Flight() { }

        public Flight(Guid id, string departureAirportCode, string departureAirportName, string destinationAirportCode, string destinationAirportName, double flightTime, double distance, double fuelNeeded, double takeOffEffort)
        {
            this.Id = id;
            this.DepartureAirportCode = departureAirportCode;
            this.DepartureAirportName = departureAirportName;
            this.DestinationAirportCode = destinationAirportCode;
            this.DestinationAirportName = destinationAirportName;
            this.FlightTime = flightTime;
            this.Distance = distance;
            this.FuelNeeded = fuelNeeded;
            this.TakeOffEffort = takeOffEffort;

        }
        public Flight(string departureAirportCode, string departureAirportName, string destinationAirportCode, string destinationAirportName, double flightTime, double distance, double fuelNeeded, double takeOffEffort)
        {
            this.DepartureAirportCode = departureAirportCode;
            this.DepartureAirportName = departureAirportName;
            this.DestinationAirportCode = destinationAirportCode;
            this.DestinationAirportName = destinationAirportName;
            this.FlightTime = flightTime;
            this.Distance = distance;
            this.FuelNeeded = fuelNeeded;
            this.TakeOffEffort = takeOffEffort;

        }
        [Key]
        public Guid Id { get; private set; }
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