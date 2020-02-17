using SkyscannerTravel.Mappers.Interfaces;
using SkyscannerTravel.Models.Responses.Quote;
using SkyscannerTravel.ViewModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Mappers
{
    public class SkyscannerMapper : ISkyscannerMapper
    {
        public ListOfQuoteViewModels MapQuotesToViewModel(ListOfQuotes listOfQuotes)
        {
            Currency currency = listOfQuotes.Currencies.FirstOrDefault();

            CurrencyViewModel currencyViewModel = new CurrencyViewModel();

            if (!(currency is null))
            {
                currencyViewModel.Code = currency.Code;
                currencyViewModel.Symbol = currency.Symbol;
                currencyViewModel.ThousandsSeparator = currency.ThousandsSeparator;
                currencyViewModel.DecimalSeparator = currency.DecimalSeparator;
                currencyViewModel.DecimalDigits = currency.DecimalDigits;
            }

            var quoteViewModels = new List<QuoteViewModel>();

            foreach (var quote in listOfQuotes.Quotes)
            {
                var outboundLeg = new OutboundLegViewModel()
                {
                    OriginPlaceName = listOfQuotes.Places.FirstOrDefault(x => x.PlaceId == quote.OutboundLeg.OriginId).Name,
                    DestinationPlaceName = listOfQuotes.Places.FirstOrDefault(x => x.PlaceId == quote.OutboundLeg.DestinationId).Name,
                    DepartureDate = quote.OutboundLeg.DepartureDate,
                    CarrierNames = quote.OutboundLeg.CarrierIds.Select(x => listOfQuotes.Carriers.FirstOrDefault(y => y.CarrierId == x).Name).ToList()
                };

                var InboundLeg = new InboundLegViewModel()
                {
                    OriginPlaceName = listOfQuotes.Places.FirstOrDefault(x => x.PlaceId == quote.InboundLeg.OriginId).Name,
                    DestinationPlaceName = listOfQuotes.Places.FirstOrDefault(x => x.PlaceId == quote.InboundLeg.DestinationId).Name,
                    DepartureDate = quote.InboundLeg.DepartureDate,
                    CarrierNames = quote.InboundLeg.CarrierIds.Select(x => listOfQuotes.Carriers.FirstOrDefault(y => y.CarrierId == x).Name).ToList()
                };

                var quoteViewModel = new QuoteViewModel()
                {
                    QuoteId = quote.QuoteId,
                    MinPrice = quote.MinPrice,
                    Direct = quote.Direct,
                    InboundLeg = InboundLeg,
                    OutboundLeg = outboundLeg
                };

                quoteViewModels.Add(quoteViewModel);
            }

            return new ListOfQuoteViewModels()
            {
                Currency = currencyViewModel,
                Quotes = quoteViewModels
            };
        }
    }
}
