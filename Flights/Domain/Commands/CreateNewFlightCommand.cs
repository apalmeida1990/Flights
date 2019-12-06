using System;
using MediatR;

namespace Flights.Domain.Commands
{
    public class CreateNewFlightCommand : FlightCommand
    {
        public double FlightTime { get; set; }
        public double TakeOffEffort { get; set; }
    }
}