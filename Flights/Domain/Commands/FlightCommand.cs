using System;
using MediatR;

namespace Flights.Domain.Commands
{
    public abstract class FlightCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string DepartureAirportCode { get; set; }
        public string DestinationAirportCode { get; set; }
        public DateTime Timestamp { get; private set; }
        protected FlightCommand()
        {
            Timestamp = DateTime.Now;
        }

    
    }
}