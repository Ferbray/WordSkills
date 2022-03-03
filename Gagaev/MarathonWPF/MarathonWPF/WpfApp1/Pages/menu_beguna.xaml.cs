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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для menu_beguna.xaml
    /// </summary>
    public partial class menu_beguna : Page
    {
        public menu_beguna()
        {
            InitializeComponent();
        }

        private void Back_Pay(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Home());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Home());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RegMarathon());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Windows.Contacts wd = new Windows.Contacts();
            wd.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new my_results());
        }
    }
}
