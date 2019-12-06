using System;
using MediatR;

namespace Flights.Domain.Commands
{
    public class UpdateFlightCommand : FlightCommand
    {
        public double FlightTime { get; set; }
        public double Distance { get; set; }
        public double FuelNeeded { get; set; }
        public double TakeOffEffort { get; set; }
    }
}