using Microsoft.Extensions.Configuration;
using SkyscannerTravel.Helpers;
using SkyscannerTravel.Mappers.Interfaces;
using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Models.Responses.Place;
using SkyscannerTravel.Models.Responses.Quote;
using SkyscannerTravel.Services.Interfaces;
using SkyscannerTravel.ViewModels.Responses;
using System.Threading.Tasks;

namespace SkyscannerTravel.Services
{
    public class SkyscannerService : ISkyscannerService
    {
        private readonly string _apiEndpoint;
        private readonly string _apiKey;
        private readonly ISkyscannerMapper _skyscannerMapper;

        public SkyscannerService(IConfiguration configuration, ISkyscannerMapper skyscannerMapper)
        {
            _apiEndpoint = configuration["Skyscanner:ApiEndpoint"];
            _apiKey = configuration["Skyscanner:ApiKey"];
            _skyscannerMapper = skyscannerMapper;
        }

        public virtual async Task<ListOfPlacesViewModels> GetPlaceByIpAddress(
            string ipAddress,
            string country = "UK",
            string currency = "GBP",
            string locale = "en-GB")
        {
            ListOfPlaces result = await HttpHelper.Get<ListOfPlaces>($"{_apiEndpoint}autosuggest/v1.0/{country}/{currency}/{locale}?id={ipAddress}-ip&apiKey={_apiKey}");

            ListOfPlacesViewModels listOfPlaceViewModels = _skyscannerMapper.MapListOfPlacesToListOfPlacesViewModel(result);
            return listOfPlaceViewModels;
        }

        public virtual async Task<ListOfContinents> GetFullListOfContinents(string languageId = "en-gb")
        {
            ListOfContinents result = await HttpHelper.Get<ListOfContinents>($"{_apiEndpoint}geo/v1.0?languageid={languageId}&apiKey={_apiKey}");
            
            return result;
        }

        public virtual async Task<ListOfQuotesViewModels> GetBrowseQuotes(
            string originPlace,
            string destinationPlace,
            string country = "UK",
            string currency = "GBP",
            string locale = "en-GB",
            string outboundPartialDate = "anytime",
            string inboundPartialDate = "")
        {
            ListOfQuotes result = await HttpHelper.Get<ListOfQuotes>($"{_apiEndpoint}browsequotes/v1.0/{country}/{currency}/{locale}/{originPlace}/{destinationPlace}/{outboundPartialDate}/{inboundPartialDate}?apiKey={_apiKey}");

            ListOfQuotesViewModels listOfQuoteViewModels = _skyscannerMapper.MapListOfQuotesToListOfQuotesViewModel(result);

            return listOfQuoteViewModels;
        }

        public virtual async Task<ListOfCountriesViewModels> GetListOfCountries(string languageId = "en-gb")
        {
            throw new System.NotImplementedException();
        }
    }
}
