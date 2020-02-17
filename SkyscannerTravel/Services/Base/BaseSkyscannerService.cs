using SkyscannerTravel.Helpers;
using SkyscannerTravel.Mappers.Interfaces;
using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Services.Interfaces;
using SkyscannerTravel.ViewModels.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Services.Base
{
    public abstract class BaseSkyscannerService : ISkyscannerService
    {
        private readonly ISkyscannerMapper _skyscannerMapper;

        public BaseSkyscannerService(ISkyscannerMapper skyscannerMapper)
        {
            _skyscannerMapper = skyscannerMapper;
        }
        public virtual async Task<ListOfCountriesViewModels> GetListOfCountries(string languageId = "en-gb")
        {
            var path = Path.Combine("Files", "get_list_of_continents.json");

            ListOfContinents listOfCotinents = await FileHelper.GetData<ListOfContinents>(path);

            ListOfCountriesViewModels listOfCountriesViewModel = _skyscannerMapper.MapListOfContinentsToListOfCountiesViewModel(listOfCotinents);

            return listOfCountriesViewModel;
        }

        public virtual async Task<ListOfCitiesViewModel> GetListOfCities(string country, string languageId = "en-gb")
        {
            var path = Path.Combine("Files", "get_list_of_continents.json");

            ListOfContinents listOfCotinents = await FileHelper.GetData<ListOfContinents>(path);

            List<City> cities = listOfCotinents.Continents.SelectMany(x => x.Countries).Where(x => x.Name.Equals(country)).SelectMany(x => x.Cities).ToList();

            ListOfCitiesViewModel listOfCitiesViewModel = _skyscannerMapper.MapListOfCitiesToListOfCitiesViewModel(cities);

            return listOfCitiesViewModel;
        }

        public abstract Task<ListOfPlacesViewModels> GetPlaceByIpAddress(string ipAddress, string country = "UK", string currency = "GBP", string locale = "en-GB");

        public abstract Task<ListOfQuotesViewModels> GetBrowseQuotes(string originPlace, string destinationPlace, string country = "UK", string currency = "GBP", string locale = "en-GB", string outboundPartialDate = "anytime", string inboundPartialDate = "");
    }
}
