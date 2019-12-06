using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.Domain;
using Flights.Models;

namespace Flights.DAL.Service.Interfaces
{
    /// <summary>
    /// Interface of Airport Service
    /// This Service keeps controllers separated from eventual business logic 
    /// Implements eventual translation between Domain Entities and ViewModels
    /// </summary>
    public interface IFlightService : IDisposable
    {
        /// <summary>
        /// Create a new Flight
        /// </summary>
        /// <param name="flightViewModel">ViewModel from Website</param>
        /// <returns>Object with request status and eventual error messages</returns>
        Task<Result> Create(FlightViewModel flightViewModel);

        /// <summary>
        /// Get All existing flights
        /// </summary>
        /// <returns>IEnumerable of FlightViewModel. Contains all flights</returns>
        IEnumerable<FlightViewModel> GetAll();
        
        /// <summary>
        /// Get a flight for a given ID.
        /// </summary>
        /// <param name="id">Unique Identifier of flight</param>
        /// <returns>Unique object with flight data</returns>
        Task<FlightViewModel> GetById(Guid id);

        /// <summary>
        /// Updates an existing flight
        /// </summary>
        /// <param name="flightViewModel">ViewModel from Website</param>
        /// <returns>Object with request status and eventual error messages</returns>
        Task<Result> Update(FlightViewModel flightViewModel);
        
    }
}