using Microsoft.Extensions.Configuration;
using SkyscannerTravel.Helpers;
using SkyscannerTravel.Mappers.Interfaces;
using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Models.Responses.Place;
using SkyscannerTravel.Models.Responses.Quote;
using SkyscannerTravel.Services.Base;
using SkyscannerTravel.Services.Interfaces;
using SkyscannerTravel.ViewModels.Responses;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Services.MoсkedServices
{
    public class MockedSkyscannerService : BaseSkyscannerService
    {
        private readonly ISkyscannerMapper _skyscannerMapper;

        public MockedSkyscannerService(ISkyscannerMapper skyscannerMapper) : base(skyscannerMapper)
        {
            _skyscannerMapper = skyscannerMapper;
        }

        public override async Task<ListOfPlacesViewModels> GetPlaceByIpAddress(
            string ipAddress,
            string country = "UK",
            string currency = "GBP",
            string locale = "en-GB")
        {
            var path = Path.Combine("Files", "get_place_80_73_11_139.json");

            var result = await FileHelper.GetData<ListOfPlaces>(path);

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
            var path = Path.Combine("Files", "get_browse_quotes_kh_kr.json");

            var result = await FileHelper.GetData<ListOfQuotes>(path);

            ListOfQuotesViewModels quoteViewModels = _skyscannerMapper.MapListOfQuotesToListOfQuotesViewModel(result);

            return quoteViewModels;
        }
    }
}
