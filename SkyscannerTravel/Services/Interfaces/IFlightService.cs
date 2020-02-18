using SkyscannerTravel.Models.Responses.Quote;
using SkyscannerTravel.ViewModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Services.Interfaces
{
    public interface IFlightService
    {
        Task<ListOfQuotesViewModels> GetBrowseQuotes(string originPlace, string destinationPlace, string country = "UK", string currency = "GBP", string locale = "en-GB", string outboundPartialDate = "anytime", string inboundPartialDate = "");
    }
}
