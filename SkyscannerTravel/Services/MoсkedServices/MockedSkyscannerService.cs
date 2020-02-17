using Microsoft.Extensions.Configuration;
using SkyscannerTravel.Helpers;
using SkyscannerTravel.Mappers.Interfaces;
using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Models.Responses.Place;
using SkyscannerTravel.Models.Responses.Quote;
using SkyscannerTravel.Services.Interfaces;
using SkyscannerTravel.ViewModels.Responses;
using System.IO;
using System.Threading.Tasks;

namespace SkyscannerTravel.Services.MoсkedServices
{
    public class MockedSkyscannerService : ISkyscannerService
    {
        private readonly ISkyscannerMapper _skyscannerMapper;

        public MockedSkyscannerService(IConfiguration configuration, ISkyscannerMapper skyscannerMapper)
        {
            _skyscannerMapper = skyscannerMapper;
        }

        public async Task<ListOfPlacesViewModels> GetPlaceByIpAddress(
            string ipAddress,
            string country = "UK",
            string currency = "GBP",
            string locale = "en-GB")
        {
            var path = Path.Combine("Files", "get_place_80_73_11_139.json");

            var result = await FileHelper.GetData<ListOfPlaces>(path);

            ListOfPlacesViewModels listOfPlaceViewModels = _skyscannerMapper.MapListOfPlacesToListOfPlacesViewModel(result);

            return listOfPlaceViewModels;
        }

        public async Task<ListOfContinents> GetFullListOfContinents(string languageId = "en-gb")
        {
            var path = Path.Combine("Files", "get_list_of_continents.json");

            return await FileHelper.GetData<ListOfContinents>(path);
        }

        public async Task<ListOfQuotesViewModels> GetBrowseQuotes(
            string originPlace,
            string destinationPlace,
            string country = "UK",
            string currency = "GBP",
            string locale = "en-GB",
            string outboundPartialDate = "anytime",
            string inboundPartialDate = "")
        {
            var path = Path.Combine("Files", "get_browse_quotes_kh_kr.json");

            var result = await FileHelper.GetData<ListOfQuotes>(path);

            ListOfQuotesViewModels quoteViewModels = _skyscannerMapper.MapListOfQuotesToListOfQuotesViewModel(result);

            return quoteViewModels;
        }

        public async Task<ListOfCountriesViewModels> GetListOfCountries(string languageId = "en-gb")
        {
            var path = Path.Combine("Files", "get_list_of_continents.json");

            ListOfContinents listOfCotinents =  await FileHelper.GetData<ListOfContinents>(path);

            ListOfCountriesViewModels listOfCountries = _skyscannerMapper.MapListOfContinentsToListOfCountiesViewModel(listOfCotinents);

            return listOfCountries;
        }
    }
}
