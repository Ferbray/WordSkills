using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfFirst.Models;

namespace WpfFirst
{
    /// <summary>
    /// Логика взаимодействия для Get.xaml
    /// </summary>
    public partial class Get : Page
    {
        public Get()
        {
            InitializeComponent();
        }


        private async void FindBoxLogin_TextChanged(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;
            var client = App.HttpClient;
            var query = HttpUtility.ParseQueryString(string.Empty);
            if (!string.IsNullOrWhiteSpace(FindBoxLogin.Text))
            {
                query["Login"] = FindBoxLogin.Text;
            }

            var builder = new UriBuilder("https://localhost:7144/User");
            builder.Query = query.ToString();
            var response = await client.GetAsync(builder.Uri);

            if (response.IsSuccessStatusCode)
            {
                var item2 = await response.Content.ReadFromJsonAsync<IEnumerable<UserWebApiModel>>(
                    new JsonSerializerOptions(JsonSerializerDefaults.Web));

                PostBoxList.ItemsSource = item2;

            }

            else
            {
                MessageBox.Show($"Ne uspeshno {response.StatusCode} {await response.Content.ReadAsStringAsync()}");
            }
            IsEnabled = true;
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
