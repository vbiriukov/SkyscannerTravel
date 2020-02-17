using Microsoft.Extensions.Configuration;
using SkyscannerTravel.Helpers;
using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Models.Responses.Place;
using SkyscannerTravel.Models.Responses.Quote;
using SkyscannerTravel.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Providers
{
    public class SkyScannerProvider : ISkyscannerProvider
    {

        private readonly string _apiEndpoint;
        private readonly string _apiKey;

        public SkyScannerProvider(IConfiguration configuration)
        {
            _apiEndpoint = configuration["Skyscanner:ApiEndpoint"];
            _apiKey = configuration["Skyscanner:ApiKey"];
        }

        public virtual async Task<ListOfPlaces> GetPlaceByIpAddress(
           string ipAddress,
           string country = "UK",
           string currency = "GBP",
           string locale = "en-GB")
        {
            ListOfPlaces result = await HttpHelper.Get<ListOfPlaces>($"{_apiEndpoint}autosuggest/v1.0/{country}/{currency}/{locale}?id={ipAddress}-ip&apiKey={_apiKey}");
            return result;
        }

        public virtual async Task<ListOfContinents> GetFullListOfContinents(string languageId = "en-gb")
        {
            ListOfContinents result = await HttpHelper.Get<ListOfContinents>($"{_apiEndpoint}geo/v1.0?languageid={languageId}&apiKey={_apiKey}");

            return result;
        }

        public virtual async Task<ListOfQuotes> GetBrowseQuotes(
            string originPlace,
            string destinationPlace,
            string country = "UK",
            string currency = "GBP",
            string locale = "en-GB",
            string outboundPartialDate = "anytime",
            string inboundPartialDate = "")
        {
            ListOfQuotes result = await HttpHelper.Get<ListOfQuotes>($"{_apiEndpoint}browsequotes/v1.0/{country}/{currency}/{locale}/{originPlace}/{destinationPlace}/{outboundPartialDate}/{inboundPartialDate}?apiKey={_apiKey}");

            return result;
        }
    }
}
