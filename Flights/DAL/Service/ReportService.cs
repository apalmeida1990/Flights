using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Flights.DAL.Repository.Interfaces;
using Flights.DAL.Service.Interfaces;
using Flights.Domain.Entity;
using Flights.Models;

namespace Flights.DAL.Service
{
    public class ReportService : IReportService
    {

        private readonly IFlightHistoryRepository _flightHistoryRepository;
        private readonly IMapper _mapper;

        public ReportService(IMapper mapper,
                             IFlightHistoryRepository flightHistoryRepository)
        {
            _mapper = mapper;
            _flightHistoryRepository = flightHistoryRepository;
        }


        public IEnumerable<FlightHistoryViewModel> GetAll()
        {
            return _flightHistoryRepository.GetAll().ProjectTo<FlightHistoryViewModel>(_mapper.ConfigurationProvider);
        }

        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}