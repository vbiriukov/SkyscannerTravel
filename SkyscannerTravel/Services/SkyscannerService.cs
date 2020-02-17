using Microsoft.Extensions.Configuration;
using SkyscannerTravel.Helpers;
using SkyscannerTravel.Mappers.Interfaces;
using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Models.Responses.Place;
using SkyscannerTravel.Models.Responses.Quote;
using SkyscannerTravel.Providers.Interfaces;
using SkyscannerTravel.Services.Base;
using SkyscannerTravel.Services.Interfaces;
using SkyscannerTravel.ViewModels.Responses;
using System.Threading.Tasks;

namespace SkyscannerTravel.Services
{
    public class SkyscannerService : BaseSkyscannerService
    {
        private readonly string _apiEndpoint;
        private readonly string _apiKey;
        private readonly ISkyscannerProvider _skyscannerProvider;
        private readonly ISkyscannerMapper _skyscannerMapper;

        public SkyscannerService(ISkyscannerProvider skyscannerProvider, ISkyscannerMapper skyscannerMapper) : base(skyscannerMapper)
        {
            _skyscannerProvider = skyscannerProvider;
            _skyscannerMapper = skyscannerMapper;
        }

        public override async Task<ListOfPlacesViewModels> GetPlaceByIpAddress(
            string ipAddress,
            string country = "UK",
            string currency = "GBP",
            string locale = "en-GB")
        {
            ListOfPlaces result = await _skyscannerProvider.GetPlaceByIpAddress(ipAddress, country, currency, locale);
            ListOfPlacesViewModels listOfPlaceViewModels = _skyscannerMapper.MapListOfPlacesToListOfPlacesViewModel(result);
            return listOfPlaceViewModels;
        }

        public override async Task<ListOfQuotesViewModels> GetBrowseQuotes(
            string originPlace,
            string destinationPlace,
            string country = "UK",
            string currency = "GBP",
            string locale = "en-GB",
            string outboundPartialDate = "anytime",
            string inboundPartialDate = "")
        {
            ListOfQuotes result = await HttpHelper.Get<ListOfQuotes>($"{_apiEndpoint}browsequotes/v1.0/{country}/{currency}/{locale}/{originPlace}/{destinationPlace}/{outboundPartialDate}/{inboundPartialDate}?apiKey={_apiKey}");

            ListOfQuotesViewModels listOfQuoteViewModels = _skyscannerMapper.MapListOfQuotesToListOfQuotesViewModel(result);

            return listOfQuoteViewModels;
        }
    }
}
