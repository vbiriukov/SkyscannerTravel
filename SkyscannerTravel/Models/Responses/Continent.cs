using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Models.Responses
{
    public class Continent
    {
        public IList<Country> Countries { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
