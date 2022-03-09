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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для sponsors_coord.xaml
    /// </summary>
    public partial class sponsors_coord : Page
    {
        private ObservableCollection<SponsorsCoordinator> _sponsors = new ObservableCollection<SponsorsCoordinator>();
        public sponsors_coord()
        {
            InitializeComponent();
            SponsorsCordGrid.IsReadOnly = true;
            SponsorsCordGrid.CanUserResizeColumns = true;
            SponsorsCordGrid.CanUserResizeRows = true;
            SponsorsCordGrid.ItemsSource = _sponsors;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _sponsors.Add(new SponsorsCoordinator(){
                Logo = "/Resources/logo.jpg",
                Name = "123456789123456789123456",
                Summa = "300$"
            });

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Home());
        }

        private void Back_Pay(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
