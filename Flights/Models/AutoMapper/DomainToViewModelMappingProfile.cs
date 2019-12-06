using AutoMapper;
using Flights.Domain.Entity;
using Flights.EventLogging.Models;

namespace Flights.Models.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Flight, FlightViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DepartureAirportCode, opt => opt.MapFrom(src => src.DepartureAirportCode))
                .ForMember(dest => dest.DepartureAirportName, opt => opt.MapFrom(src => src.DepartureAirportName))
                .ForMember(dest => dest.DestinationAirportCode, opt => opt.MapFrom(src => src.DestinationAirportCode))
                .ForMember(dest => dest.DestinationAirportName, opt => opt.MapFrom(src => src.DestinationAirportName))
                .ForMember(dest => dest.FlightTime, opt => opt.MapFrom(src => src.FlightTime))
                .ForMember(dest => dest.Distance, opt => opt.MapFrom(src => src.Distance))
                .ForMember(dest => dest.FuelNeeded, opt => opt.MapFrom(src => src.FuelNeeded))
                .ForMember(dest => dest.TakeOffEffort, opt => opt.MapFrom(src => src.TakeOffEffort));

            CreateMap<Airport, AirportViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude));

            CreateMap<FlightHistory, FlightHistoryViewModel>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId));


            CreateMap<FlightHistoryViewModel, FlightHistory>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId));

        }
    }
}