using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SkyscannerTravel.Helpers
{
    public class HttpHelper
    {
        private const string HTTP_METHOD_GET = "GET";
        private const string HTTP_ACCEPT_TYPE = "application/json";

        public static async Task<R> Get<R>(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;

            request.Method = HTTP_METHOD_GET;
            request.Accept = HTTP_ACCEPT_TYPE;

            using (var response = await request.GetResponseAsync() as HttpWebResponse)
            {
                using (Stream stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream);
                    string responseString = await reader.ReadToEndAsync();
                    R result = JsonConvert.DeserializeObject<R>(responseString);
                    return result;
                }
            }
        }
    }
}
