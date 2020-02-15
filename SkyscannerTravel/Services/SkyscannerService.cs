using Microsoft.Extensions.Configuration;
using SkyscannerTravel.Helpers;
using SkyscannerTravel.Models.Responses;
using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Models.Responses.Place;
using SkyscannerTravel.Models.Responses.Quote;
using SkyscannerTravel.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SkyscannerTravel.Services
{
    public class SkyscannerService : ISkyscannerService
    {
        private readonly string _apiEndpoint;
        private readonly string _apiKey;

        public SkyscannerService(IConfiguration configuration)
        {
            _apiEndpoint = configuration["Skyscanner:ApiEndpoint"];
            _apiKey = configuration["Skyscanner:ApiKey"];

        }

        public async Task<ListOfPlaces> GetListOfPlaces(
            string ipAddress,
            string country = "UK",
            string currency = "GBP",
            string locale = "en-GB")
        {
            var result = await HttpHelper.OnGet<ListOfPlaces>($"{_apiEndpoint}autosuggest/v1.0/{country}/{currency}/{locale}?id ={ipAddress}-ip&apiKey={_apiKey}");
            return result.Item2;
        }

        public async Task<ListOfContinents> GetListOfContinents(string languageId = "en-gb")
        {
            var result = await HttpHelper.OnGet<ListOfContinents>($"{_apiEndpoint}geo/v1.0?languageid={languageId}&apiKey={_apiKey}");
            return result.Item2;
        }

        public async Task<Quote> GetBrowseQuotes(
            string originPlace,
            string destinationPlace,
            string country = "UK",
            string currency = "GBP",
            string locale = "en-GB",
            string outboundPartialDate = "anytime",
            string inboundPartialDate = "")
        {
            var result = await HttpHelper.OnGet<Quote>($"{_apiEndpoint}browsequotes/v1.0/{country}/{currency}/{locale}/{originPlace}/{destinationPlace}/{outboundPartialDate}/{inboundPartialDate}?apiKey={_apiKey}");
            return result.Item2;
        }

        public Task<ListOfPlaces> GetPlaceByIpAddress(string ipAddress, string country = "UK", string currency = "GBP", string locale = "en-GB")
        {
            throw new System.NotImplementedException();
        }

        public Task<ListOfPlaces> SearchPlace(string query, string country = "UK", string currency = "GBP", string locale = "en-GB")
        {
            throw new System.NotImplementedException();
        }

        public Task<ListOfContinents> GetFullListOfContinents(string languageId = "en-gb")
        {
            throw new System.NotImplementedException();
        }

        Task<ListOfQuotes> ISkyscannerService.GetBrowseQuotes(string originPlace, string destinationPlace, string country, string currency, string locale, string outboundPartialDate, string inboundPartialDate)
        {
            throw new System.NotImplementedException();
        }
    }
}
