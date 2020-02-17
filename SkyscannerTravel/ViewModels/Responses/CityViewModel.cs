using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.ViewModels.Responses
{
    public class CityViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class ListOfCitiesViewModel
    {
       public IList<CityViewModel> Cities { get; set; }
        public ListOfCitiesViewModel()
        {
            Cities = new List<CityViewModel>();
        }
    }
}
