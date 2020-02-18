using SkyscannerTravel.ViewModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Services.Interfaces
{
    public interface ILocationService
    {
        Task<ListOfPlacesViewModels> GetPlaceByIpAddress(string ipAddress, string country = "UK", string currency = "GBP", string locale = "en-GB");
        Task<ListOfCountriesViewModels> GetListOfCountries(string languageId = "en-gb");
        Task<ListOfCitiesViewModel> GetListOfCities(string country, string languageId = "en-gb");
    }
}
