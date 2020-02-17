using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyscannerTravel.Filters
{
    public class ErrorFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public ErrorFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(typeof(ErrorFilter));
        }
        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.Message, context.Exception.StackTrace);
            context.ExceptionHandled = true;
        }
    }
}
