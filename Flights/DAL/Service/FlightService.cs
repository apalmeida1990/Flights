using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Flights.DAL.Repository.Interfaces;
using Flights.DAL.Service.Interfaces;
using Flights.Domain;
using Flights.Domain.Commands;
using Flights.Models;
using MediatR;

namespace Flights.DAL.Service
{
    /// <summary>
    /// Mediatr framework injected to manage Commands and Events Handling.
    /// Can be replaced by a proper messaging system, like RabbitMq.
    /// Mediatr implements something like InMemory messaging
    /// </summary>
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public FlightService(IMapper mapper,
                             IFlightRepository flightRepository,
                             IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _flightRepository = flightRepository;

        }

        public IEnumerable<FlightViewModel> GetAll()
        {
            return _flightRepository.GetAll().ProjectTo<FlightViewModel>(_mapper.ConfigurationProvider);
        }


        public async Task<FlightViewModel> GetById(Guid id)
        {
            var flight = await _flightRepository.GetById(id);
            return _mapper.Map<FlightViewModel>(flight);
        }

        public async Task<Result> Create(FlightViewModel flightViewModel)
        {
            var registerCommand = _mapper.Map<CreateNewFlightCommand>(flightViewModel);
            return await _mediator.Send(registerCommand);
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> Update(FlightViewModel flightViewModel)
        {
            var updateCommand = _mapper.Map<UpdateFlightCommand>(flightViewModel);
            return await _mediator.Send(updateCommand);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}