using AutoMapper;
using Flights.Domain.Entity;
using Flights.EventLogging.EventNotification;
using Flights.EventLogging.Models;

namespace Flights.Models.AutoMapper
{
    public class EventLogToDomainMappingProfile : Profile
    {
        public EventLogToDomainMappingProfile()

        {
            CreateMap<UpdateFlightEventLog, FlightHistory>()
                .ForMember(dest => dest.ActionDate, opt => opt.MapFrom(src => src.Timestamp));
            CreateMap<CreateNewFlightEventLog, FlightHistory>()
                .ForMember(dest => dest.ActionDate, opt => opt.MapFrom(src => src.Timestamp));
            CreateMap<Flight, CreateNewFlightEventLog>()
                .ForMember(dest => dest.EntityId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DepartureAirportCode, opt => opt.MapFrom(src => src.DepartureAirportCode))
                .ForMember(dest => dest.DepartureAirportName, opt => opt.MapFrom(src => src.DepartureAirportName))
                .ForMember(dest => dest.DestinationAirportCode, opt => opt.MapFrom(src => src.DestinationAirportCode))
                .ForMember(dest => dest.DestinationAirportName, opt => opt.MapFrom(src => src.DestinationAirportName))
                .ForMember(dest => dest.FlightTime, opt => opt.MapFrom(src => src.FlightTime))
                .ForMember(dest => dest.Distance, opt => opt.MapFrom(src => src.Distance))
                .ForMember(dest => dest.FuelNeeded, opt => opt.MapFrom(src => src.FuelNeeded))
                .ForMember(dest => dest.TakeOffEffort, opt => opt.MapFrom(src => src.TakeOffEffort));
            CreateMap<Flight, UpdateFlightEventLog>()
                .ForMember(dest => dest.EntityId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DepartureAirportCode, opt => opt.MapFrom(src => src.DepartureAirportCode))
                .ForMember(dest => dest.DepartureAirportName, opt => opt.MapFrom(src => src.DepartureAirportName))
                .ForMember(dest => dest.DestinationAirportCode, opt => opt.MapFrom(src => src.DestinationAirportCode))
                .ForMember(dest => dest.DestinationAirportName, opt => opt.MapFrom(src => src.DestinationAirportName))
                .ForMember(dest => dest.FlightTime, opt => opt.MapFrom(src => src.FlightTime))
                .ForMember(dest => dest.Distance, opt => opt.MapFrom(src => src.Distance))
                .ForMember(dest => dest.FuelNeeded, opt => opt.MapFrom(src => src.FuelNeeded))
                .ForMember(dest => dest.TakeOffEffort, opt => opt.MapFrom(src => src.TakeOffEffort));
        }
    }
}