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
    /// Логика взаимодействия для Postuplenie.xaml
    /// </summary>
    public partial class Postuplenie : Page
    {
        public Postuplenie()
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
            Manager.MainFrame.GoBack();
        }
    }
}
