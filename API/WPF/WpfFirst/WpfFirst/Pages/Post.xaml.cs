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
    /// Логика взаимодействия для Post.xaml
    /// </summary>
    public partial class Post : Page
    {
        public Post()
        {
            InitializeComponent();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private async void Button_Click_Async(object sender, RoutedEventArgs e)
        {
            UserWebApiModel user = new UserWebApiModel
            {
                Login = FindBoxLogin.Text,
                Email = FindBoxEmail.Text,
                Password = FindBoxPassword.Text,
            };

            IsEnabled = false;
            var content = JsonContent.Create(user);
            var client = App.HttpClient;
            var response = await client.PostAsync("https://localhost:7144/User", content);

            if (response.IsSuccessStatusCode)
            {
                this.NavigationService.GoBack();
            }

            else
            {
                MessageBox.Show($"Ne uspeshno {response.StatusCode} {await response.Content.ReadAsStringAsync()}");
            }
            IsEnabled = true;
        }
    }
}
