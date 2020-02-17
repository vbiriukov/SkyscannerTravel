using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using SkyscannerTravel.Filters;
using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Services.Interfaces;
using SkyscannerTravel.ViewModels.Responses;

namespace SkyscannerTravel.Controllers
{
    [ServiceFilter(typeof(ErrorFilter))]
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

            ListOfPlacesViewModels listOfPlaces = await _skyscannerService.GetPlaceByIpAddress(clientIpAddress);
            ListOfCountriesViewModels listOfCountries = await _skyscannerService.GetListOfCountries();


            return View((listOfCountries, listOfPlaces));
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
            ListOfQuotesViewModels listOfQuoteViewModels = await _skyscannerService.GetBrowseQuotes(orininalPlace,destinationPlace);

            return new PartialViewResult
            {
                ViewName = "~/Views/Shared/Partials/_BrowseQuotesPartial.cshtml",
                ViewData = new ViewDataDictionary<ListOfQuotesViewModels>(ViewData, listOfQuoteViewModels)
            };
        }
    }
}
