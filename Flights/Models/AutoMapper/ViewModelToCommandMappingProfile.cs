using AutoMapper;
using Flights.Domain.Commands;

namespace Flights.Models.AutoMapper
{
    public class ViewModelToCommandMappingProfile : Profile
    {
        public ViewModelToCommandMappingProfile()
        {
            CreateMap<FlightViewModel, UpdateFlightCommand>();
            CreateMap<FlightViewModel, CreateNewFlightCommand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DepartureAirportCode, opt => opt.MapFrom(src => src.DepartureAirportCode))
                .ForMember(dest => dest.DestinationAirportCode, opt => opt.MapFrom(src => src.DestinationAirportCode))
                .ForMember(dest => dest.FlightTime, opt => opt.MapFrom(src => src.FlightTime))
                .ForMember(dest => dest.TakeOffEffort, opt => opt.MapFrom(src => src.TakeOffEffort));
        }
        
    }
}