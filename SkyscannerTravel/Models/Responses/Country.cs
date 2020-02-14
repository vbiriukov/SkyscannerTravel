using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Models.Responses
{
    public class Country
    {
        public string CurrencyId { get; set; }
        public IList<Region> Regions { get; set; }
        public IList<City> Cities { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
