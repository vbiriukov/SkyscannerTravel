using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Models.Responses.Quote
{
    public class OutboundLeg
    {
        public IList<int> CarrierIds { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime DepartureDate { get; set; }

        public OutboundLeg()
        {
            CarrierIds = new List<int>();
        }
    }

    public class InboundLeg
    {
        public IList<int> CarrierIds { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime DepartureDate { get; set; }

        public InboundLeg()
        {
            CarrierIds = new List<int>();
        }
    }

    public class Quote
    {
        public int QuoteId { get; set; }
        public double MinPrice { get; set; }
        public bool Direct { get; set; }
        public OutboundLeg OutboundLeg { get; set; }
        public InboundLeg InboundLeg { get; set; }
        public DateTime QuoteDateTime { get; set; }

        public Quote()
        {
            InboundLeg = new InboundLeg();
            OutboundLeg = new OutboundLeg();
        }
    }

    public class Place
    {
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SkyscannerCode { get; set; }
        public string IataCode { get; set; }
        public string CityName { get; set; }
        public string CityId { get; set; }
        public string CountryName { get; set; }
    }

    public class Carrier
    {
        public int CarrierId { get; set; }
        public string Name { get; set; }
    }

    public class Currency
    {
        public string Code { get; set; }
        public string Symbol { get; set; }
        public string ThousandsSeparator { get; set; }
        public string DecimalSeparator { get; set; }
        public bool SymbolOnLeft { get; set; }
        public bool SpaceBetweenAmountAndSymbol { get; set; }
        public int RoundingCoefficient { get; set; }
        public int DecimalDigits { get; set; }
    }

    public class ListOfQuotes
    {
        public IList<Quote> Quotes { get; set; }
        public IList<Place> Places { get; set; }
        public IList<Carrier> Carriers { get; set; }
        public IList<Currency> Currencies { get; set; }

        public ListOfQuotes()
        {
            Quotes = new List<Quote>();
            Places = new List<Place>();
            Carriers = new List<Carrier>();
            Currencies = new List<Currency>();
        }
    }
}
