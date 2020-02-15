using System.Collections.Generic;

namespace SkyscannerTravel.Models.Responses.Place
{
    public class ListOfPlaces
    {
        public IList<Place> Places { get; set; }

        public ListOfPlaces()
        {
            Places = new List<Place>();
        }
    }

    public class Place
    {
        public string PlaceId { get; set; }
        public string PlaceName { get; set; }
        public string CountryId { get; set; }
        public string RegionId { get; set; }
        public string CityId { get; set; }
        public string CountryName { get; set; }
    }
}
