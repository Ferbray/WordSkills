using System;
using System.Collections.Generic;
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
using WpfFirst.Pages;

namespace WpfFirst
{
    /// <summary>
    /// Логика взаимодействия для HomePages.xaml
    /// </summary>
    public partial class HomePages : Page
    {
        public HomePages()
        {
            InitializeComponent();
        }

        private void Button_Get(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Get());
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Edit());
        }

        private void Button_Post(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Post());
        }
        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Delete());
        }
    }
}
