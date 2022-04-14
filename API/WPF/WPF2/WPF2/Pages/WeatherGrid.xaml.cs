using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
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

namespace WPF2.Pages
{
    /// <summary>
    /// Логика взаимодействия для WeatherGrid.xaml
    /// </summary>
    public partial class WeatherGrid : Page
    {
        public WeatherGrid()
        {
            InitializeComponent();
            WeatherTable.IsReadOnly = true;
            WeatherTable.CanUserResizeColumns = true;
            WeatherTable.CanUserResizeRows = true;
        }

        private async void WeatherTable_Loaded(object sender, RoutedEventArgs e)
        {
            var client = App.HttpClient;
            var response = await client.GetAsync("https://localhost:7144/WeatherForecast");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<List<WeatherForecast>>(
                    new System.Text.Json.JsonSerializerOptions(System.Text.Json.JsonSerializerDefaults.Web));
                WeatherTable.ItemsSource = content;
            }

            else
            {
                MessageBox.Show("GG WP");
            }
        }
    }
}
