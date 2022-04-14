using System;
using System.Collections.Generic;
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
using WpfFirst.Models;

namespace WpfFirst.Pages
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        public Edit()
        {
            InitializeComponent();
        }

        private async void Button_EditAsync(object sender, RoutedEventArgs e) {

            UserWebApiModel user = new UserWebApiModel
            {
                Id = int.Parse(EditBoxID.Text),
                Login = EditBoxLogin.Text,
                Email = EditBoxEmail.Text,
                Password = EditBoxPassword.Text,
                isBan = EditBoxIsBan.IsEnabled  == true ? 1 : 0,
                isAdmin = EditBoxIsAdmin.IsEnabled == true ? 1 : 0, 
                isMute = EditBoxIsMute.IsEnabled == true ? 1 : 0,
                Photo = EditBoxPhoto.Text,
                Description = EditBoxDescription.Text,
            };

            IsEnabled = false;
            var content = JsonContent.Create(user);
            var client = App.HttpClient;
            var response = await client.PutAsync($"https://localhost:7144/User/{EditBoxID.Text}", content);

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

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
