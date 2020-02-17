using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using SkyscannerTravel.Models;
using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Models.Responses.Place;
using SkyscannerTravel.Models.Responses.Quote;
using SkyscannerTravel.Services.Interfaces;
using SkyscannerTravel.ViewModels.Responses;

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

        [HttpGet("{ip?}")]
        public async Task<IActionResult> Index(string ip)
        {
            if (!IPAddress.TryParse(ip, out IPAddress remoteIpAddress))
            {
                remoteIpAddress = HttpContext.Connection.RemoteIpAddress;
            }

            if (remoteIpAddress.IsIPv4MappedToIPv6)
            {
                remoteIpAddress = remoteIpAddress.MapToIPv4();
            }

            string clientIpAddress = remoteIpAddress?.ToString();

            ListOfQuoteViewModels qoutes = await _skyscannerService.GetBrowseQuotes(string.Empty, string.Empty);
            ListOfPlaces listOfPlaces = await _skyscannerService.GetPlaceByIpAddress(clientIpAddress);
            ListOfContinents listOfCointinents = await _skyscannerService.GetFullListOfContinents();


            return View((listOfCointinents, qoutes, listOfPlaces));
        }

        public class Location
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }

        [HttpGet("/Cities/Nearest")]
        public async Task<IActionResult> GetPlaces(double latitude, double longitude)
        {
            ListOfContinents listOfCointinents = await _skyscannerService.GetFullListOfContinents();
            var listOfCities = listOfCointinents.Continents
                .SelectMany(x => x.Countries)
                .SelectMany(x => x.Cities)
                .Where(x => GetCity(x,latitude, longitude))
                .OrderBy(x => x.Name)
                .Select(x => x.Name);

            return Ok(listOfCities);
        }

        private bool GetCity(City city, double latitude, double longitude)
        {
            string[] locations = city.Location.Split(",");
            if (double.TryParse(locations[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double resultLat) 
                && double.TryParse(locations[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double resultLong))
            {
                double deviationLat = Math.Abs(resultLat - latitude);
                double deviationLong = Math.Abs(resultLong - longitude);

                return (deviationLat < 2d && deviationLong < 2d);
            }
            return false;
        }

        [HttpGet("/Cities/{country}")]
        public async Task<IActionResult> GetCities(string country)
        {
            ListOfContinents listOfCointinents = await _skyscannerService.GetFullListOfContinents();
            var listOfCities = listOfCointinents.Continents
                .SelectMany(x => x.Countries)
                .Where(x => x.Name.Equals(country))
                .SelectMany(x => x.Cities)
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem() { 
                    Text = x.Name,
                    Value = x.Id
                });

            return Ok(listOfCities);
        }

        [HttpGet("/BrowseQuotes")]
        public async Task<IActionResult> GetBrowseQuotes(string orininalPlace, string destinationPlace)
        {
            ListOfQuoteViewModels listOfQuoteViewModels = await _skyscannerService.GetBrowseQuotes(orininalPlace,destinationPlace);

            return new PartialViewResult
            {
                ViewName = "~/Views/Shared/Partials/_BrowseQuotesPartial.cshtml",
                ViewData = new ViewDataDictionary<ListOfQuoteViewModels>(ViewData, listOfQuoteViewModels)
            };
        }

        [HttpGet("/Airports/{country}/{city}")]
        public async Task<IActionResult> GetAirports(string country, string city)
        {
            ListOfContinents listOfCointinents = await _skyscannerService.GetFullListOfContinents();
            IEnumerable<string> listOfCities = listOfCointinents.Continents
                .SelectMany(x => x.Countries)
                .Where(x => x.Name.Equals(country))
                .SelectMany(x => x.Cities)
                .Where(x => x.Name.Equals(city))
                .SelectMany(x => x.Airports)
                .OrderBy(x => x.Name)
                .Select(x => x.Name);

            return Ok(listOfCities);
        }
    }
}
