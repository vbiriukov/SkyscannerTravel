using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Models.Responses.Place;
using SkyscannerTravel.Models.Responses.Quote;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SkyscannerTravel.Services.Interfaces
{
    public interface ISkyscannerService
    {
        Task<ListOfPlaces> GetPlaceByIpAddress(string ipAddress, string country = "UK", string currency = "GBP", string locale = "en-GB");
        Task<ListOfPlaces> SearchPlace(string query, string country = "UK", string currency = "GBP", string locale = "en-GB");
        Task<ListOfContinents> GetFullListOfContinents(string languageId = "en-gb");
        Task<ListOfQuotes> GetBrowseQuotes(string originPlace, string destinationPlace, string country = "UK", string currency = "GBP", string locale = "en-GB", string outboundPartialDate = "anytime", string inboundPartialDate = "");
    }
}
