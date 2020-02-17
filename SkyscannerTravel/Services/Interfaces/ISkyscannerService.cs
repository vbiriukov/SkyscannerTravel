using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.ViewModels.Responses;
using System.Threading.Tasks;

namespace SkyscannerTravel.Services.Interfaces
{
    public interface ISkyscannerService
    {
        Task<ListOfPlacesViewModels> GetPlaceByIpAddress(string ipAddress, string country = "UK", string currency = "GBP", string locale = "en-GB");
        Task<ListOfCountriesViewModels> GetListOfCountries(string languageId = "en-gb");
        Task<ListOfCitiesViewModel> GetListOfCities(string country, string languageId = "en-gb");
        Task<ListOfQuotesViewModels> GetBrowseQuotes(string originPlace, string destinationPlace, string country = "UK", string currency = "GBP", string locale = "en-GB", string outboundPartialDate = "anytime", string inboundPartialDate = "");

    }
}
