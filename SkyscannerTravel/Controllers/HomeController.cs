using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkyscannerTravel.Models;
using SkyscannerTravel.Services.Interfaces;

namespace SkyscannerTravel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISkyscannerService _skyscannerService;

        public HomeController(ILogger<HomeController> logger, ISkyscannerService skyscannerService)
        {
            _logger = logger;
            _skyscannerService = skyscannerService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _skyscannerService.GetFullListOfContinents();
            var result1 = await _skyscannerService.GetPlaceByIpAddress(string.Empty);
            var result2 = await _skyscannerService.GetBrowseQuotes(string.Empty, string.Empty);
            var result3 = await _skyscannerService.SearchPlace("kh");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
