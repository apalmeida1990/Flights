using System;
using System.Collections.Generic;
using Flights.Models;

namespace Flights.DAL.Service.Interfaces
{
    /// <summary>
    /// Interface of Report Service
    /// This Service keeps controllers separated from eventual business logic 
    /// Implements eventual translation between Domain Entities and ViewModels
    /// </summary>
    public interface IReportService : IDisposable
    {
        /// <summary>
        /// Get all existing Flight History Data
        /// </summary>
        /// <returns>IEnumerable with all existing History</returns>
        IEnumerable<FlightHistoryViewModel> GetAll();
    }
}