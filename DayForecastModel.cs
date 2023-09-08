using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherForecast
{
    [XmlRoot("root")]
    public class RootContainer : INotifyPropertyChanged
    {
        [XmlElement("current")]
        public TodayForecastContainer TodayForecast { get; set; }
        [XmlElement("forecast")]
        public ForecastContainer ForecastData { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs( propertyName ) );
        }
    }

    public class TodayForecastContainer : RootContainer
    {
        [XmlElement("wind_kph")]
        public double windSpeed { get; set; }
        [XmlElement("pressure_mb")]
        public double pressure { get; set; }
        private int humidity;
        [XmlElement("humidity")]
        public int Humidity
        {
            get { return humidity; }
            set
            {
                if(humidity != value)
                {
                    humidity = value;
                    OnPropertyChanged(nameof(Humidity));
                }
            }
        }


    }
    public class ForecastContainer
    {
        [XmlElement("forecastday")]
        public ForecastDay[] ForecastDays { get; set; }
    }

    public class ForecastDay
    {
        [XmlIgnore]
        public string Date { get; set; }

        [XmlElement("date")]
        public string SerializableDate
        {
            get => Date;
            set => Date = DateTransformator(value);
        }


        [XmlElement("day")]
        public Day DayData { get; set; }


        private string DateTransformator(string date)
        {
            DateTime currentDate = DateTime.Parse(date);
            CultureInfo culture = new CultureInfo("en-US");
            return currentDate.ToString("dddd", culture);
        }
    }
    public class Day
    {
        public double maxtemp_c { get; set; }
        public double mintemp_c { get; set; }
        
        public double daily_chance_of_rain { get; set; }
        public int avghumidity { get; set; }

        [XmlElement("condition")]
        public DayCondition DayCondition { get; set; }
    }
    public class DayCondition
    {
        private string condition;
        [XmlElement("text")]
        public string Condition {
            get
            {
                return condition;
            }
            set
            {
                condition = value;
                imageUrlChooser(condition);
            }
        }
        public string imageUrl { get; set; }
        private void imageUrlChooser(string Condition)
        {
            StringBuilder root = new StringBuilder();
            string absolutePath = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
            root.Append(absolutePath);
            root.Append("\\data\\");
            if(Condition == null || Condition.Length == 0)
            {
                imageUrl = "";
            }
            else
            {
                switch (Condition)
                {
                    case "Sunny":
                        imageUrl = "sun_480px.png";
                        break;
                    case "Partly cloudy":
                        imageUrl = "partly_cloudy_day_320px.png";
                        break;
                    case "Cloudy":
                        imageUrl = "cloud_480px.png";
                        break;
                    case "Overcast":
                        imageUrl = "clouds_512px.png";
                        break;
                    case "Mist":
                        imageUrl = "fog_192px.png";
                        break;
                    case "Fog":
                        imageUrl = "fog_192px.png";
                        break;
                    case "Freezing fog":
                        imageUrl = "fog_192px.png";
                        break;
                    case "Patchy rain possible":
                        imageUrl = "light_rain_480px.png";
                        break;
                    case "Patchy light rain":
                        imageUrl = "light_rain_480px.png";
                        break;
                    case "Light rain":
                        imageUrl = "light_rain_480px.png";
                        break;
                    case "Patchy light snow":
                        imageUrl = "snow_512px.png";
                        break;
                    case "Light snow":
                        imageUrl = "snow_512px.png";
                        break;
                    case "Patchy snow possible":
                        imageUrl = "snow_512px.png";
                        break;
                    case "Light snow showers":
                        imageUrl = "snow_512px.png";
                        break;
                    case "Patchy freezing drizzle possible":
                        imageUrl = "snow_512px.png";
                        break;
                    case "Freezing drizzle":
                        imageUrl = "snow_512px.png";
                        break;
                    case "Thundery outbreaks possible":
                        imageUrl = "storm_480px.png";
                        break;
                    case "Heavy freezing drizzle":
                        imageUrl = "snowH_512px.png";
                        break;
                    case "Patchy moderate snow":
                        imageUrl = "snowH_512px.png";
                        break;
                    case "Moderate snow":
                        imageUrl = "snowH_512px.png";
                        break;
                    case "Blizzard":
                        imageUrl = "snowH_512px.png";
                        break;
                    case "Patchy heavy snow":
                        imageUrl = "snowH_512px.png";
                        break;
                    case "Moderate or heavy snow showers":
                        imageUrl = "snowH_512px.png";
                        break;
                    case "Heavy snow":
                        imageUrl = "snowH_512px.png";
                        break;
                    case "Blowing snow":
                        imageUrl = "blowing_snow_192px.png";
                        break;
                    case "Patchy light drizzle":
                        imageUrl = "rain_cloud_480px.png";
                        break;
                    case "Light drizzle":
                        imageUrl = "rain_cloud_480px.png";
                        break;
                    case "Moderate rain at times":
                        imageUrl = "rain_480px.png";
                        break;
                    case "Moderate rain":
                        imageUrl = "rain_480px.png";
                        break;
                    case "Heavy rain at times":
                        imageUrl = "rain_480px.png";
                        break;
                    case "Heavy rain":
                        imageUrl = "rain_480px.png";
                        break;
                    case "Moderate or heavy rain shower":
                        imageUrl = "rain_480px.png";
                        break;
                    case "Torrential rain shower":
                        imageUrl = "rain_480px.png";
                        break;
                    case "Light freezing rain":
                        imageUrl = "sleet_480px.png";
                        break;
                    case "Moderate or heavy freezing rain":
                        imageUrl = "sleet_480px.png";
                        break;
                    case "Light sleet":
                        imageUrl = "sleet_480px.png";
                        break;
                    case "Moderate or heavy sleet":
                        imageUrl = "sleet_480px.png";
                        break;
                    case "Patchy sleet possible":
                        imageUrl = "sleet_480px.png";
                        break;
                    case "Ice pellets":
                        imageUrl = "sleet_480px.png";
                        break;
                    case "Light showers of ice pellets":
                        imageUrl = "sleet_480px.png";
                        break;
                    case "Moderate or heavy showers of ice pellets":
                        imageUrl = "sleet_480px.png";
                        break;
                    case "Light sleet showers":
                        imageUrl = "sleet_480px.png";
                        break;
                    case "Moderate or heavy sleet showers":
                        imageUrl = "sleet_480px.png";
                        break;
                    case "Patchy light rain with thunder":
                        imageUrl = "cloud_with_lightning_and_rain_192px.png";
                        break;
                    case "Moderate or heavy rain with thunder":
                        imageUrl = "cloud_with_lightning_and_rain_192px.png";
                        break;
                    case "Patchy light snow with thunder":
                        imageUrl = "cloud_with_lightning_and_rain_192px.png";
                        break;
                    case "Moderate or heavy snow with thunder":
                        imageUrl = "cloud_with_lightning_and_rain_192px.png";
                        break;
                }
                root.Append(imageUrl);
                imageUrl = root.ToString();
            }

        }
    }
}
