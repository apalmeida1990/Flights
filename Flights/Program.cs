using System;
using Flights.DAL.Context;
using Flights.Migrations.SeedData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Flights
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Invoke seeder function
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                try
                {
                    var context = services.GetRequiredService<FlightContext>();
                    // Always try apply last migrations. If tables didnt exist, they are created at this point.
                    context.Database.Migrate();
                    // Seed Airports Tables
                    Seed.SeedAirports(context, logger);
                }
                catch (Exception ex)
                {
                    
                    logger.LogError(ex, "An error occured during migration.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
