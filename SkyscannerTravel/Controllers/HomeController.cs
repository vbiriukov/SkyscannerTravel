using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using SkyscannerTravel.Extensions;
using SkyscannerTravel.Filters;
using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Services.Interfaces;
using SkyscannerTravel.ViewModels.Responses;

namespace SkyscannerTravel.Controllers
{
    [ServiceFilter(typeof(ErrorFilter))]
    public class HomeController : Controller
    {
        private readonly ISkyscannerService _skyscannerService;

        public HomeController(ISkyscannerService skyscannerService)
        {
            _skyscannerService = skyscannerService;
        }

        public async Task<IActionResult> Index()
        {
            string clientIpAddress = HttpContext.GetIpAddress();

            ListOfPlacesViewModels listOfPlaces = await _skyscannerService.GetPlaceByIpAddress(clientIpAddress);
            ListOfCountriesViewModels listOfCountries = await _skyscannerService.GetListOfCountries();


            return View((listOfCountries, listOfPlaces));
        }

        [HttpGet("/Cities/{country}")]
        public async Task<IActionResult> GetCities(string country)
        {
            ListOfCitiesViewModel listOfCities = await _skyscannerService.GetListOfCities(country);
     
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
