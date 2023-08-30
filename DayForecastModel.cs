using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherForecast
{
    [XmlRoot("root")]
    public class RootContainer
    {
        [XmlElement("forecast")]
        public ForecastContainer ForecastData { get; set; }
    }

    public class ForecastContainer
    {
        [XmlElement("forecastday")]
        public ForecastDay[] ForecastDays { get; set; }
    }

    public class ForecastDay : INotifyPropertyChanged
    {
        [XmlElement("date")]
        public string date { get; set; }
        public string Date
        {
            get => date;
            set => date = DateTransformator(value);
        }


        [XmlElement("day")]
        public Day DayData { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

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
        [XmlElement("text")]
        public string Condition {get; set; }
    }
}
