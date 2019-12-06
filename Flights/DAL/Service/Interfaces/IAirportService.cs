using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.Models;

namespace Flights.DAL.Service.Interfaces
{
    /// <summary>
    /// Interface of Airport Service
    /// This Service keeps controllers separated from eventual business logic 
    /// Implements eventual translation between Domain Entities and ViewModels
    /// </summary>
    public interface IAirportService : IDisposable
    {
        /// <summary>
        /// Get all existing Flight History Data
        /// </summary>
        /// <returns>IEnumerable with all existing History</returns>
        IEnumerable<AirportViewModel> GetAll();
    }
}