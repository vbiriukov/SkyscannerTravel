using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.ViewModels.Responses
{

    public class ListOfPlacesViewModels
    {
        public IList<PlaceViewModel> Places { get; set; }

        public ListOfPlacesViewModels()
        {
            Places = new List<PlaceViewModel>();
        }

    }
    public class PlaceViewModel
    {
        public string PlaceId { get; set; }
        public string PlaceName { get; set; }
    }
}
