using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.ViewModels.Responses
{
    public class ListOfCountriesViewModels
    {
        public IList<CountyViewModel> Countries { get; set; }

        public ListOfCountriesViewModels()
        {
            Countries = new List<CountyViewModel>();
        }
    }

    public class CountyViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
