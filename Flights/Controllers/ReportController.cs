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
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        
        /// <summary>
        /// Constructor injects all dependencies
        /// </summary>
        /// <param name="ReportService">Interface for Report Service (Service-Repository Pattern)</param>
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            var model = _reportService.GetAll();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
