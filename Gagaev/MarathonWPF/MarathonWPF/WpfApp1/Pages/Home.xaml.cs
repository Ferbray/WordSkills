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
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void TextBlock_Initialized(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            (sender as TextBlock).Text = "Москва, Россия\n" + time.ToString("dddd d MMMM yyyy");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Begun1());
        }

        private void Begun2_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Begun1();
        }

        private void Begun3_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Begun1();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.Login());
        }
    }
}
