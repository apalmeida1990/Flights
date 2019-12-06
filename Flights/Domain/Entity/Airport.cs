using System;
using AutoMapper;

namespace Flights.Domain.Entity
{
    public class Airport
    {

        public Airport() { }
        public Airport(string id, string name, double longitude, double latitude)
        {
            this.Id = id;
            this.Name = name;
            this.Longitude = longitude;
            this.Latitude = latitude;

        }
        public string Id { get; set; }
        public string Name { get;  set; }
        public double Longitude { get;  set; }
        public double Latitude { get;  set; }

        public override String ToString()
        {
            return $"ID: {this.Id}, Name: {this.Name}, Longitude: {this.Longitude}, Latitute: {this.Latitude}";
        }

    }
}