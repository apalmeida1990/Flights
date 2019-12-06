using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Flights.Models
{
    public class FlightViewModel
    {   [Key]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Departure Airport is required")]
        [MinLength(3)]
        [MaxLength(3)]
        [DisplayName("Departure Airport")]
        public string DepartureAirportCode { get; set; }

        public string DepartureAirportName { get; set; }
        
        [Required(ErrorMessage = "Destination Airport is required")]
        [MinLength(3)]
        [MaxLength(3)]
        [DisplayName("Destination Airport")]
        public string DestinationAirportCode { get; set; }
        
        public string DestinationAirportName { get; set; }
        
        [DisplayName("Flight Time")]
         public double FlightTime { get; set; }
        
        [DisplayName("Distance")]
        public double Distance { get; set; }
        
        [DisplayName("Fuel Needed")]
        public double FuelNeeded { get; set; }

        [Required(ErrorMessage = "Takeoff Effort is required")]
        [DisplayName("TakeOff Effort")]
        public double TakeOffEffort { get; set; }

        public override string ToString() {
            return $"ID --> {Id} \r\n DepartureAirportCode --> {DepartureAirportCode}" + 
             $"\r\n DepartureAirportName --> {DepartureAirportName}" +
             $"\r\n DestinationAirportCode --> {DestinationAirportCode}" +
             $"\r\n DestinationAirportName --> {DestinationAirportName}" +
             $"\r\n FlightTime --> {FlightTime}" +
             $"\r\n Distance --> {Distance}" +
             $"\r\n FuelNeeded --> {FuelNeeded}" +
             $"\r\n TakeOffEffort --> {TakeOffEffort}";

        }
    }
}