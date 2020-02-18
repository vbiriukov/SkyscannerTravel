using SkyscannerTravel.Mappers.Interfaces;
using SkyscannerTravel.Services.Interfaces;

namespace SkyscannerTravel.Services
{
    public class SkyscannerService : ISkyscannerService
    {
        public IFlightService Flight { get; private set; }

        public ILocationService Location { get; private set; }

        public SkyscannerService(IFlightService flightSservice, ILocationService locationService, ISkyscannerMapper skyscannerMapper)
        {
            Flight = flightSservice;
            Location = locationService;
        }
    }
}
