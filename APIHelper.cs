using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast
{
    public static class APIHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitialiseClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("http://api.weatherapi.com/v1/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
