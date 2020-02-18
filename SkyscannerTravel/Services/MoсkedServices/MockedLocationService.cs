using SkyscannerTravel.Contants;
using SkyscannerTravel.Helpers;
using SkyscannerTravel.Mappers.Interfaces;
using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Models.Responses.Place;
using SkyscannerTravel.Services.Interfaces;
using SkyscannerTravel.ViewModels.Responses;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Services.MoсkedServices
{
    public class MockedLocationService : ILocationService
    {
        private readonly ISkyscannerMapper _skyscannerMapper;

        public MockedLocationService(ISkyscannerMapper skyscannerMapper)
        {
            _skyscannerMapper = skyscannerMapper;
        }

        public async Task<ListOfCountriesViewModels> GetListOfCountries(string languageId = "en-gb")
        {
            ListOfContinents listOfCotinents = await FileHelper.GetData<ListOfContinents>(FileName.PARENT_FOLDER, FileName.LIST_CONTINENTS);

            ListOfCountriesViewModels listOfCountriesViewModel = _skyscannerMapper.MapListOfContinentsToListOfCountiesViewModel(listOfCotinents);

            return listOfCountriesViewModel;
        }

        public async Task<ListOfCitiesViewModel> GetListOfCities(string country, string languageId = "en-gb")
        {
            ListOfContinents listOfCotinents = await FileHelper.GetData<ListOfContinents>(FileName.PARENT_FOLDER, FileName.LIST_CONTINENTS);

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
            ListOfPlaces listOfPlaces = await FileHelper.GetData<ListOfPlaces>(FileName.PARENT_FOLDER, FileName.PLACE_IP_80_73_11_139);

            ListOfPlacesViewModels listOfPlaceViewModels = _skyscannerMapper.MapListOfPlacesToListOfPlacesViewModel(listOfPlaces);

            return listOfPlaceViewModels;
        }
    }
}
