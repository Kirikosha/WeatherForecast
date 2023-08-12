using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast
{
    public class DayForecastModel
    {
        string date { get; set; }
        string name { get; set; }
        int temp_c { get; set; }
        int temp_f { get; set; }
        int feelslike_c { get; set; }
        int feelslike_f { get;set; }
        int condition { get; set; }
        int wind_kph { get; set; }
        string wind_dir { get; set; }

        int pressure_mb { get; set; }
        int humidity { get; set; }

    }
}
