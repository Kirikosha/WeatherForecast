using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast
{
    public static class UserInputAnalyser
    {
        private static string city;
        public static string City
        {
            get { return city; }
            set
            {
                if(value == "")
                {
                    value = "berlin";
                }
                value = value.Trim();
                value = value.ToLower();
                city = value;
            }
        }
    }
}
