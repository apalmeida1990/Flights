using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Flights.DAL.Repository.Interfaces;
using Flights.Domain.Entity;
using Flights.EventLogging.EventNotification;
using Flights.EventLogging.Models;
using MediatR;

namespace Flights.EventLogging.EventHandler
{
    /// <summary>
    /// Implementation of Notification/Event Handler
    /// Mediatr Framework allows to publish notification.
    /// This class implements a simple Event Sourcing Mechanism Handling.await
    /// Every Command will eventually generate a Notification.await
    /// Here will be persisted in database all changes made to an domain entity.
    /// </summary>
    public class EventLoggingHandler : INotificationHandler<CreateNewFlightEventLog>,
                                       INotificationHandler<UpdateFlightEventLog>
    {
        private readonly IFlightHistoryRepository _repository;
        private readonly IMapper _mapper;
        public EventLoggingHandler(IFlightHistoryRepository repository,
                                   IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = repository;

        }
        public async Task Handle(CreateNewFlightEventLog notification, CancellationToken cancellationToken)
        {
            var flight = _mapper.Map<FlightHistory>(notification);
            _repository.Add(flight);
            await _repository.SaveChanges();
        }

        public async Task Handle(UpdateFlightEventLog notification, CancellationToken cancellationToken)
        {
            var flight = _mapper.Map<FlightHistory>(notification);
            _repository.Add(flight);
            await _repository.SaveChanges();
        }
    }
}