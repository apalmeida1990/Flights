﻿// <auto-generated />
using System;
using Flights.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flights.Migrations
{
    [DbContext(typeof(FlightContext))]
    partial class FlightContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Flights.Domain.Entity.Airport", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("Flights.Domain.Entity.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DepartureAirportCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureAirportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationAirportCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationAirportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<double>("FlightTime")
                        .HasColumnType("float");

                    b.Property<double>("FuelNeeded")
                        .HasColumnType("float");

                    b.Property<double>("TakeOffEffort")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Flights.EventLogging.Models.FlightHistory", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureAirportCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureAirportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationAirportCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationAirportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("FlightTime")
                        .HasColumnType("float");

                    b.Property<double>("FuelNeeded")
                        .HasColumnType("float");

                    b.Property<double>("TakeOffEffort")
                        .HasColumnType("float");

                    b.HasKey("EventId");

                    b.ToTable("FlightHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
