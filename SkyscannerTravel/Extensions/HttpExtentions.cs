using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SkyscannerTravel.Extensions
{
    public static class HttpExtentions
    {
        public static string GetIpAddress(this HttpContext httpContext)
        {
            IPAddress remoteIpAddress = httpContext.Connection.RemoteIpAddress;

            if (remoteIpAddress.IsIPv4MappedToIPv6)
            {
                remoteIpAddress = remoteIpAddress.MapToIPv4();
            }

            return remoteIpAddress?.ToString();
        }
    }
}
