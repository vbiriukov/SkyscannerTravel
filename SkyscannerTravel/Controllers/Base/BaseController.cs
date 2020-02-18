using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkyscannerTravel.Exceptions;
using SkyscannerTravel.Filters;
using System;
using System.Threading.Tasks;

namespace SkyscannerTravel.Controllers.Base
{
    [ServiceFilter(typeof(ErrorFilter))]
    public class BaseController : Controller
    {
        private readonly ILogger _logger;

        public BaseController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(typeof(ErrorFilter));
        }

        public async Task<R> Execute<R>(Func<Task<R>> func) where R : new()
        {
            R response = new R();
            try
            {
                response = await func();
            }catch (ManyRequestException ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }

            return response;
        }
    }
}
