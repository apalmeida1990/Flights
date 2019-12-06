using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Flights.DAL.Repository.Interfaces;
using Flights.Domain.Commands;
using Flights.Domain.Entity;
using Flights.EventLogging.EventNotification;
using Flights.Helper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Flights.Domain.CommandHandlers
{
    /// <summary>
    /// Implementation of Flight related Commands (CQRS pattern)
    /// Uses framework Mediatr
    /// </summary>
    public class FlightCommandHandler : IRequestHandler<CreateNewFlightCommand, Result>,
                                        IRequestHandler<UpdateFlightCommand, Result>
    {
        private const char Kilometer = 'K';
        private readonly IMediator _mediator;
        private readonly IAirportRepository _airportRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public FlightCommandHandler(IMediator mediator,
                                    IAirportRepository airportRepository,
                                    IFlightRepository flightRepository,
                                    IMapper mapper)
        {
            this._flightRepository = flightRepository;
            this._mapper = mapper;
            this._airportRepository = airportRepository;
            this._mediator = mediator;
        }

        public async Task<Result> Handle(CreateNewFlightCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // todo: Add eventual Business Validations.

                var departureAirport = _airportRepository.GetByIataCode(request.DepartureAirportCode);
                var destinationAirport = _airportRepository.GetByIataCode(request.DestinationAirportCode);

                // Calculate distance between
                var distance = GeoLocation.distance(departureAirport.Latitude, departureAirport.Longitude,
                                                    destinationAirport.Latitude, destinationAirport.Longitude,
                                                    Kilometer);

                // Calculate Fuel Needed
                var fuelNeeded = distance / request.FlightTime + request.TakeOffEffort;

                var flight = new Flight(departureAirport.Id,
                                        departureAirport.Name,
                                        destinationAirport.Id,
                                        destinationAirport.Name,
                                        request.FlightTime,
                                        distance,
                                        fuelNeeded,
                                        request.TakeOffEffort);

                _flightRepository.Add(flight);
                await _flightRepository.SaveChanges();
                
                // Publish a Notification. Notification Handler will implement an Event Sourcing mechanism
                await _mediator.Publish(_mapper.Map<CreateNewFlightEventLog>(flight));

                return new Result(true, string.Empty);
            }
            catch (System.Exception ex)
            {
                return new Result(false, ex.Message);
            }


        }

        public async Task<Result> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // todo: This is not good practice. Todo: Get Airport Name from View
                var departureAirport = _airportRepository.GetByIataCode(request.DepartureAirportCode);
                var destinationAirport = _airportRepository.GetByIataCode(request.DestinationAirportCode);

                var flight = new Flight(request.Id,
                                        departureAirport.Id,
                                        departureAirport.Name,
                                        destinationAirport.Id,
                                        destinationAirport.Name,
                                        request.FlightTime,
                                        request.Distance,
                                        request.FuelNeeded,
                                        request.TakeOffEffort);

                _flightRepository.Update(flight);
                await _flightRepository.SaveChanges();

                // Publish a Notification. Notification Handler will implement an Event Sourcing mechanism
                await _mediator.Publish(_mapper.Map<UpdateFlightEventLog>(flight));

                return new Result(true, string.Empty);
            }
            catch (System.Exception ex)
            {
                return new Result(false, ex.Message);
            }

        }
    }
}