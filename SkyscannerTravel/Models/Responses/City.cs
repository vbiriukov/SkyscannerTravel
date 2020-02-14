using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Models.Responses
{
    public class City
    {
        public bool SingleAirportCity { get; set; }
        public IList<Airport> Airports { get; set; }
        public string CountryId { get; set; }
        public string Location { get; set; }
        public string IataCode { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
