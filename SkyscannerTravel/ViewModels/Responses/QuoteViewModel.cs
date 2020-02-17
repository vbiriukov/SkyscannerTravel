using System;
using System.Collections.Generic;

namespace SkyscannerTravel.ViewModels.Responses
{
    public class ListOfQuotesViewModels
    {
        public CurrencyViewModel Currency { get; set; }
        public IList<QuoteViewModel> Quotes { get; set; }

        public ListOfQuotesViewModels()
        {
            Currency = new CurrencyViewModel();
            Quotes = new List<QuoteViewModel>();
        }
    }

    public class QuoteViewModel
    {
        public int QuoteId { get; set; }
        public double MinPrice { get; set; }
        public bool Direct { get; set; }

        public OutboundLegViewModel OutboundLeg { get; set; }
        public InboundLegViewModel InboundLeg { get; set; }

        public QuoteViewModel()
        {
            InboundLeg = new InboundLegViewModel();
            OutboundLeg = new OutboundLegViewModel();
        }
    }

    public class OutboundLegViewModel
    {
        public IList<string> CarrierNames { get; set; }
        public string OriginPlaceName { get; set; }
        public string DestinationPlaceName { get; set; }
        public DateTime DepartureDate { get; set; }

        public OutboundLegViewModel()
        {
            CarrierNames = new List<string>();
        }
    }

    public class InboundLegViewModel
    {
        public IList<string> CarrierNames { get; set; }
        public string OriginPlaceName { get; set; }
        public string DestinationPlaceName { get; set; }
        public DateTime DepartureDate { get; set; }

        public InboundLegViewModel()
        {
            CarrierNames = new List<string>();
        }
    }

    public class CurrencyViewModel { 
        public string Code { get; set; }
        public string Symbol { get; set; }
        public string ThousandsSeparator { get; set; }
        public string DecimalSeparator { get; set; }
        public int DecimalDigits { get; set; }
    }
}
