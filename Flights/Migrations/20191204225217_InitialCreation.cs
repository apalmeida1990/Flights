using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flights.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightHistory",
                columns: table => new
                {
                    EventId = table.Column<Guid>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    DepartureAirportCode = table.Column<string>(nullable: true),
                    DepartureAirportName = table.Column<string>(nullable: true),
                    DestinationAirportCode = table.Column<string>(nullable: true),
                    DestinationAirportName = table.Column<string>(nullable: true),
                    FlightTime = table.Column<double>(nullable: false),
                    Distance = table.Column<double>(nullable: false),
                    FuelNeeded = table.Column<double>(nullable: false),
                    TakeOffEffort = table.Column<double>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    ActionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightHistory", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DepartureAirportCode = table.Column<string>(nullable: true),
                    DepartureAirportName = table.Column<string>(nullable: true),
                    DestinationAirportCode = table.Column<string>(nullable: true),
                    DestinationAirportName = table.Column<string>(nullable: true),
                    FlightTime = table.Column<double>(nullable: false),
                    Distance = table.Column<double>(nullable: false),
                    FuelNeeded = table.Column<double>(nullable: false),
                    TakeOffEffort = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "FlightHistory");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
