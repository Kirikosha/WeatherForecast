using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherForecast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ForecastDay selectedDay { get; set; }
        public IList<ForecastDay> Days { get; set; }
        WeatherDeserialiser weatherDeserialiser;
        public RootContainer forecast { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            weatherDeserialiser = new WeatherDeserialiser();
        }

        private async void searchForecast_Click(object sender, RoutedEventArgs e)
        {
            string city = SearchField.Text;
            if (String.IsNullOrEmpty(city))
            {
                city = "Kiev";
            }
            UserInputAnalyser.City = city;
            APIHelper.InitialiseClient();
            await DayForecastCreating(UserInputAnalyser.City);
            DataLoadIntoLabel();
            DaysListBox.SelectedIndex = 0;
            EmptyNotificator.Visibility = Visibility.Collapsed;
            SelectedGrid.Visibility = Visibility.Visible;
            

        }

        private async Task DayForecastCreating(string city)
        {
            var dayforecast = await WeatherProcessor.LoadForecast(city);
            if(dayforecast != null)
            {
                forecast = weatherDeserialiser.Deserialize(dayforecast);    // передача прогнозу погоди в програму
                Days = forecast.ForecastData.ForecastDays.ToList();
                DaysListBox.ItemsSource = Days;
                DaysListBox.Items.Refresh();
            }
        }

        private void DataLoadIntoLabel()
        {
            Humidity.Content = forecast.TodayForecast.Humidity;
            WindSpeed.Content = forecast.TodayForecast.windSpeed;
            Pressure.Content = forecast.TodayForecast.pressure;
            double rainProbabilityValue = forecast.ForecastData.ForecastDays[0].DayData.daily_chance_of_rain;
            RainProbability.Content = rainProbabilityValue;
        }

        private void ForecastListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDay = DaysListBox.SelectedItem as ForecastDay;
            if (selectedDay != null)
            {
                selectedDayDate.Text = selectedDay.Date;
                SelectedDayHumidity.Text = selectedDay.DayData.avghumidity.ToString();
                SelectedDayMinTemperature.Text = selectedDay.DayData.mintemp_c.ToString();
                SelectedDayMaxTemperature.Text = selectedDay.DayData.maxtemp_c.ToString();
                SelectedDayCondition.Text = selectedDay.DayData.DayCondition.Condition;
                SelectedDayRainPos.Text = selectedDay.DayData.daily_chance_of_rain.ToString();
            }
        }
    }
}
