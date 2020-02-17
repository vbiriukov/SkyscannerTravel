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
        ListOfQuoteViewModels MapQuotesToViewModel(ListOfQuotes listOfQuotes);
    }
}
