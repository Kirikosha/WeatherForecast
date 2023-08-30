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
        public IList<ForecastDay> Days { get; set; }
        WeatherDeserialiser weatherDeserialiser;
        RootContainer forecast;
        public MainWindow()
        {
            InitializeComponent();
            weatherDeserialiser = new WeatherDeserialiser();
        }

        private async void searchForecast_Click(object sender, RoutedEventArgs e)
        {
            UserInputAnalyser.City = SearchField.Text;
            APIHelper.InitialiseClient();
            await DayForecastCreating();
            Humidity.Content = forecast.ForecastData.ForecastDays[0].DayData.avghumidity;
            
        }

        private async Task DayForecastCreating()
        {
            var dayforecast = await WeatherProcessor.LoadForecast();
            if(dayforecast != null)
            {
                forecast = weatherDeserialiser.Deserialize(dayforecast);    // передача прогнозу погоди в програму
                Days = forecast.ForecastData.ForecastDays.ToList();
                DaysListBox.ItemsSource = Days;
                DaysListBox.Items.Refresh();
            }
        }
    }
}
