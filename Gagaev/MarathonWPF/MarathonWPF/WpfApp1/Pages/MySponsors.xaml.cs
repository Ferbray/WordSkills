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
using System.Collections.ObjectModel;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для MySponsors.xaml
    /// </summary>
    public partial class MySponsors : Page
    {
        private ObservableCollection<Sponsors> _sponsors = new ObservableCollection<Sponsors>();
        public MySponsors()
        {
            InitializeComponent();
            SponsorsGrid.IsReadOnly = true;
            SponsorsGrid.CanUserResizeColumns = true;
            SponsorsGrid.CanUserResizeRows = true;
            SponsorsGrid.ItemsSource = _sponsors;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            string random_char = "ABCDEFGHIJKLMNOPQVZX123456";
            string random_string = "";
            int random_pay = random.Next(10, 10000);

            for (int i = 0; i<random.Next(3, 12); i++)
                random_string += random_char[random.Next(0, random_char.Length)];

            _sponsors.Add((new Sponsors()
            {
                Sponsor = random_string,
                Pay = random_pay
            }));
        }

        private void Back_Pay(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Home());
        }
    }
}
