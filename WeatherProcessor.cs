using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace WeatherForecast
{
    public class WeatherProcessor
    {
        public static async Task<string> LoadForecast(string city)
        {
            string url = $"forecast.xml?key=f8eea4dfae9f407c814212739230908&q={city}&days=3&aqi=no&alerts=no";
            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    return responseBody;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
