using SkyscannerTravel.Contants;
using SkyscannerTravel.Helpers;
using SkyscannerTravel.Mappers.Interfaces;
using SkyscannerTravel.Models.Responses.Quote;
using SkyscannerTravel.Services.Interfaces;
using SkyscannerTravel.ViewModels.Responses;
using System.IO;
using System.Threading.Tasks;

namespace SkyscannerTravel.Services.MoсkedServices
{
    public class MockedFlightService : IFlightService
    {
        private readonly ISkyscannerMapper _skyscannerMapper;

        public MockedFlightService(ISkyscannerMapper skyscannerMapper)
        {
            _skyscannerMapper = skyscannerMapper;
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
            var result = await FileHelper.GetData<ListOfQuotes>(FileName.PARENT_FOLDER, FileName.BROWSE_QUOTES_KH_KR);

            ListOfQuotesViewModels quoteViewModels = _skyscannerMapper.MapListOfQuotesToListOfQuotesViewModel(result);

            return quoteViewModels;
        }
    }
}
