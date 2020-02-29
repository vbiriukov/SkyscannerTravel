using Microsoft.Extensions.Configuration;
using SkyscannerTravel.Contants;
using SkyscannerTravel.Helpers;
using SkyscannerTravel.Mappers.Interfaces;
using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Models.Responses.Place;
using SkyscannerTravel.Providers.Interfaces;
using SkyscannerTravel.Services.Interfaces;
using SkyscannerTravel.ViewModels.Responses;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Services
{
    public class LocationService : ILocationService
    {
        private readonly ISkyscannerProvider _skyscannerProvider;
        private readonly ISkyscannerMapper _skyscannerMapper;

        public LocationService(ISkyscannerProvider skyscannerProvider, ISkyscannerMapper skyscannerMapper, IConfiguration configuration)
        {
            _skyscannerProvider = skyscannerProvider;
            _skyscannerMapper = skyscannerMapper;
        }

        public async Task<ListOfCountriesViewModels> GetListOfCountries(string languageId = "en-gb")
        {
            ListOfContinents listOfCotinents = await GetFullListOfContinents(languageId);

            ListOfCountriesViewModels listOfCountriesViewModel = _skyscannerMapper.MapListOfContinentsToListOfCountiesViewModel(listOfCotinents);

            return listOfCountriesViewModel;
        }

        public async Task<ListOfCitiesViewModel> GetListOfCities(string country, string languageId = "en-gb")
        {
            ListOfContinents listOfCotinents = await GetFullListOfContinents(languageId);

            List<City> cities = listOfCotinents.Continents.SelectMany(x => x.Countries).Where(x => x.Name.Equals(country)).SelectMany(x => x.Cities).ToList();

            ListOfCitiesViewModel listOfCitiesViewModel = _skyscannerMapper.MapListOfCitiesToListOfCitiesViewModel(cities);

            return listOfCitiesViewModel;
        }
        public async Task<ListOfPlacesViewModels> GetPlaceByIpAddress(
            string ipAddress,
            string country = "UK",
            string currency = "GBP",
            string locale = "en-GB")
        {
            ListOfPlaces listOfPlaces = await _skyscannerProvider.GetPlaceByIpAddress(ipAddress, country, currency, locale);

            ListOfPlacesViewModels listOfPlaceViewModels = _skyscannerMapper.MapListOfPlacesToListOfPlacesViewModel(listOfPlaces);

            return listOfPlaceViewModels;
        }

        private async Task<ListOfContinents> GetFullListOfContinents(string languageId)
        {
            ListOfContinents listOfContinents = await _skyscannerProvider.GetFullListOfContinents(languageId);

            return listOfContinents;
        }
    }
}
