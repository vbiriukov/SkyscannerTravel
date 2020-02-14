using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Models.Responses
{
    public class PlaceList
    {
        public IList<Place> Places { get; set; }
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
