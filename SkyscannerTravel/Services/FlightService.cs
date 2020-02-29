using SkyscannerTravel.Mappers.Interfaces;
using SkyscannerTravel.Models.Responses.Quote;
using SkyscannerTravel.Providers.Interfaces;
using SkyscannerTravel.Services.Interfaces;
using SkyscannerTravel.ViewModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Services
{
    public class FlightService : IFlightService
    {
        private readonly ISkyscannerProvider _skyscannerProvider;
        private readonly ISkyscannerMapper _skycannerMapper;

        public FlightService(ISkyscannerProvider skyscannerProvider, ISkyscannerMapper skycannerMapper)
        {
            _skyscannerProvider = skyscannerProvider;
            _skycannerMapper = skycannerMapper;
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

            ListOfQuotes result = await _skyscannerProvider.GetBrowseQuotes(originPlace, destinationPlace, country, currency, locale, outboundPartialDate, inboundPartialDate);

            ListOfQuotesViewModels listOfQuoteViewModels = _skycannerMapper.MapListOfQuotesToListOfQuotesViewModel(result);

            return listOfQuoteViewModels;
        }
    }
}
