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

namespace WpfFirst.Pages
{
    /// <summary>
    /// Логика взаимодействия для Delete.xaml
    /// </summary>
    public partial class Delete : Page
    {
        public Delete()
        {
            InitializeComponent();
        }

        private async Task Button_DeleteAsync(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;
            var client = App.HttpClient;
            var response = await client.DeleteAsync($"https://localhost:7144/{DeleteBoxID}");

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
