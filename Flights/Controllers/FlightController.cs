using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Flights.Models;
using Flights.DAL.Service.Interfaces;

namespace Flights.Controllers
{
    public class FlightController : Controller
    {
        private readonly ILogger<FlightController> _logger;
        private readonly IFlightService _flightService;
        private readonly IAirportService _airportService;

        /// <summary>
        /// Constructor injects all dependencies
        /// </summary>
        /// <param name="logger">ILogger Interface for logging purposes</param>
        /// <param name="FlightService">Interface for Flight Service (Service-Repository Pattern)</param>
        /// <param name="AirportService">Interface for Airport Service (Service-Repository Pattern)</param>
        public FlightController(ILogger<FlightController> logger,
                                IFlightService FlightService,
                                IAirportService AirportService)
        {
            _airportService = AirportService;
            _flightService = FlightService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = _flightService.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightViewModel = await _flightService.GetById(id.Value);

            if (flightViewModel == null)
            {
                return NotFound();
            }

            return View(flightViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FlightViewModel flight)
        {
            _logger.LogInformation(flight.ToString());
            var result = _flightService.Create(flight);
            if (result.Result.Status)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        public IActionResult GetAllAirports()
        {
            try
            {
                var airports = _airportService.GetAll();
                if (!airports.Any())
                {
                    return NotFound();
                }
                return Ok(airports);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Failed to retrieve airports");
                return BadRequest("Failed to retrieve airports");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FlightViewModel flight)
        {
            if (!ModelState.IsValid) return View(flight);

            var result = _flightService.Update(flight);
            if (result.Result.Status)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
