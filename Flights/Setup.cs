using System.Reflection;
using AutoMapper;
using Flights.DAL.Repository;
using Flights.DAL.Repository.Interfaces;
using Flights.DAL.Service;
using Flights.DAL.Service.Interfaces;
using Flights.Domain;
using Flights.Domain.CommandHandlers;
using Flights.Domain.Commands;
using Flights.EventLogging.EventHandler;
using Flights.EventLogging.EventNotification;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Flights
{
    public static class Setup
    {
        public static void ConfigureInjections(this IServiceCollection services)
        {
             // Inject Repositories
            services.AddScoped<IAirportRepository, AirportRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IFlightHistoryRepository, FlightHistoryRepository>();

            // Inject Service
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<IReportService, ReportService>();

            //Inject AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //Inject Mediatr Library
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Inject MediatrHandler
            services.AddScoped<IRequestHandler<CreateNewFlightCommand, Result>, FlightCommandHandler>();
            services.AddScoped<INotificationHandler<CreateNewFlightEventLog>, EventLoggingHandler>();
        }

    }
}