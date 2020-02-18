namespace SkyscannerTravel.Services.Interfaces
{
    public interface ISkyscannerService
    {
        IFlightService Flight { get; }
        ILocationService Location { get; }
    }
}
