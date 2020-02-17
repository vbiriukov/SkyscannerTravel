using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Models.Responses.Place;
using SkyscannerTravel.Models.Responses.Quote;
using SkyscannerTravel.ViewModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Mappers.Interfaces
{
    public interface ISkyscannerMapper
    {
        ListOfQuotesViewModels MapListOfQuotesToListOfQuotesViewModel(ListOfQuotes listOfQuotes);
        ListOfPlacesViewModels MapListOfPlacesToListOfPlacesViewModel(ListOfPlaces listOfPlaces);
        ListOfCountriesViewModels MapListOfContinentsToListOfCountiesViewModel(ListOfContinents listOfContinents);
    }
}
