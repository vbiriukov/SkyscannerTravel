using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Models.Responses.Place;
using SkyscannerTravel.Models.Responses.Quote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Providers.Interfaces
{
    public interface ISkyscannerProvider
    {
        Task<ListOfPlaces> GetPlaceByIpAddress(string ipAddress, string country = "UK", string currency = "GBP", string locale = "en-GB");
        Task<ListOfContinents> GetFullListOfContinents(string languageId = "en-gb");
        Task<ListOfQuotes> GetBrowseQuotes(string originPlace, string destinationPlace, string country = "UK", string currency = "GBP", string locale = "en-GB", string outboundPartialDate = "anytime", string inboundPartialDate = "");
    }
}
