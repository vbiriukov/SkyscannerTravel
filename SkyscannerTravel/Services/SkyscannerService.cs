using Microsoft.Extensions.Configuration;
using SkyscannerTravel.Helpers;
using SkyscannerTravel.Mappers.Interfaces;
using SkyscannerTravel.Models.Responses;
using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Models.Responses.Place;
using SkyscannerTravel.Models.Responses.Quote;
using SkyscannerTravel.Services.Interfaces;
using SkyscannerTravel.ViewModels.Responses;
using System.Collections.Generic;
using System.IO;
using System.Net;
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

        public async Task<ListOfPlaces> GetPlaceByIpAddress(
            string ipAddress,
            string country = "UK",
            string currency = "GBP",
            string locale = "en-GB")
        {
            var result = await HttpHelper.OnGet<ListOfPlaces>($"{_apiEndpoint}autosuggest/v1.0/{country}/{currency}/{locale}?id ={ipAddress}-ip&apiKey={_apiKey}");
            return result.Item2;
        }

        public async Task<ListOfContinents> GetFullListOfContinents(string languageId = "en-gb")
        {
            var result = await HttpHelper.OnGet<ListOfContinents>($"{_apiEndpoint}geo/v1.0?languageid={languageId}&apiKey={_apiKey}");
            return result.Item2;
        }

        public async Task<ListOfQuoteViewModels> GetBrowseQuotes(
            string originPlace,
            string destinationPlace,
            string country = "UK",
            string currency = "GBP",
            string locale = "en-GB",
            string outboundPartialDate = "anytime",
            string inboundPartialDate = "")
        {
            (HttpStatusCode ResponseCode, ListOfQuotes ListOfQuotes) result = await HttpHelper.OnGet<ListOfQuotes>($"{_apiEndpoint}browsequotes/v1.0/{country}/{currency}/{locale}/{originPlace}/{destinationPlace}/{outboundPartialDate}/{inboundPartialDate}?apiKey={_apiKey}");
            
            ListOfQuoteViewModels listOfQuoteViewModels = _skyscannerMapper.MapQuotesToViewModel(result.ListOfQuotes);
            
            return listOfQuoteViewModels;
        }

        public Task<ListOfPlaces> SearchPlace(string query, string country = "UK", string currency = "GBP", string locale = "en-GB")
        {
            throw new System.NotImplementedException();
        }
    }
}
