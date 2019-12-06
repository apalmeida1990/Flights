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
    public class AirportService : IAirportService
    {

        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;

        public AirportService(IMapper mapper,
            IAirportRepository airportRepository)
        {
            _mapper = mapper;
            _airportRepository = airportRepository;

        }
        public AirportViewModel GetByIataCode(string code)
        {
            var airport = _airportRepository.GetByIataCode(code);
            return  _mapper.Map<Airport, AirportViewModel>(airport);

        }
        public IEnumerable<AirportViewModel> GetAll()
        {
            var airports = _airportRepository.GetAll();
            return airports.ProjectTo<AirportViewModel>(_mapper.ConfigurationProvider).ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}