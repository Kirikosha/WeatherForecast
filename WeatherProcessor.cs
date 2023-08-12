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
        public static async Task<DayForecastModel> LoadForecast()
        {
            string url = "forecast.json?key=f8eea4dfae9f407c814212739230908&q=Berlin&days=3&aqi=no&alerts=no";
            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    DayForecastModel day = await response.Content.ReadAsAsync<DayForecastModel>();

                    return day;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
