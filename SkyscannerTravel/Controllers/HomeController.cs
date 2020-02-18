using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using SkyscannerTravel.Controllers.Base;
using SkyscannerTravel.Extensions;
using SkyscannerTravel.Services.Interfaces;
using SkyscannerTravel.ViewModels.Responses;

namespace SkyscannerTravel.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISkyscannerService _skyscannerService;

        public HomeController(ISkyscannerService skyscannerService, ILoggerFactory loggerFactory) : base(loggerFactory)
        {
            _skyscannerService = skyscannerService;
        }

        public async Task<IActionResult> Index()
        {
            string clientIpAddress = HttpContext.GetIpAddress();

            ListOfPlacesViewModels listOfPlaces = await Execute(() => _skyscannerService.Location.GetPlaceByIpAddress(clientIpAddress));
            ListOfCountriesViewModels listOfCountries = await Execute(() => _skyscannerService.Location.GetListOfCountries());


            return View((listOfCountries, listOfPlaces));
        }

        [HttpGet("/Cities/{country}")]
        public async Task<IActionResult> GetCities(string country)
        {
            ListOfCitiesViewModel listOfCities = await Execute(() => _skyscannerService.Location.GetListOfCities(country));

            return Ok(listOfCities);
        }

        [HttpGet("/BrowseQuotes")]
        public async Task<IActionResult> GetBrowseQuotes(string orininalPlace, string destinationPlace)
        {
            ListOfQuotesViewModels listOfQuoteViewModels = await Execute(() => _skyscannerService.Flight.GetBrowseQuotes(orininalPlace, destinationPlace));

            return new PartialViewResult
            {
                ViewName = "~/Views/Shared/Partials/_BrowseQuotesPartial.cshtml",
                ViewData = new ViewDataDictionary<ListOfQuotesViewModels>(ViewData, listOfQuoteViewModels)
            };
        }
    }
}
