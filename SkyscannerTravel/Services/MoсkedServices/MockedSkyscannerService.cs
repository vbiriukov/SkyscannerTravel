using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SkyscannerTravel.Helpers;
using SkyscannerTravel.Models.Responses;
using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Models.Responses.Place;
using SkyscannerTravel.Models.Responses.Quote;
using SkyscannerTravel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyscannerTravel.Services.MoсkedServices
{
    public class MockedSkyscannerService : ISkyscannerService
    {
        private readonly string _apiEndpoint;
        private readonly string _apiKey;

        public MockedSkyscannerService(IConfiguration configuration)
        {
            _apiEndpoint = configuration["Skyscanner:ApiEndpoint"];
            _apiKey = configuration["Skyscanner:ApiKey"];

        }

        public async Task<ListOfPlaces> GetPlaceByIpAddress(
            string ipAddress,
            string country = "UK",
            string currency = "GBP",
            string locale = "en-GB")
        {
            var path = Path.Combine("Files", "get_list_of_places.json");

            return await FileHelper.GetData<ListOfPlaces>(path);
        }

        public async Task<ListOfContinents> GetFullListOfContinents(string languageId = "en-gb")
        {
            var path = Path.Combine("Files", "get_list_of_continents.json");

            return await FileHelper.GetData<ListOfContinents>(path);
        }

        public async Task<ListOfQuotes> GetBrowseQuotes(
            string originPlace,
            string destinationPlace,
            string country = "UK",
            string currency = "GBP",
            string locale = "en-GB",
            string outboundPartialDate = "anytime",
            string inboundPartialDate = "")
        {
            //var path = Path.Combine("Files", "get_list_of_places.json");
            var path = Path.Combine("Files", "get_browse_quotes_kh_kr.json");

            return await FileHelper.GetData<ListOfQuotes>(path);
        }

        public async Task<ListOfPlaces> SearchPlace(string query, string country = "UK", string currency = "GBP", string locale = "en-GB")
        {
            var path = Path.Combine("Files", $"search_place_{query}.json");

            return await FileHelper.GetData<ListOfPlaces>(path);
        }
    }
}
