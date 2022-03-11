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
    /// Логика взаимодействия для sponsors_admin.xaml
    /// </summary>
    public partial class sponsors_admin : Page
    {
        private ObservableCollection<SponsorsAdmin> _admin = new ObservableCollection<SponsorsAdmin>();
        public sponsors_admin()
        {
            InitializeComponent();
            SponsorsAdminGrid.IsReadOnly = true;
            SponsorsAdminGrid.CanUserResizeColumns = true;
            SponsorsAdminGrid.CanUserResizeRows = true;
            SponsorsAdminGrid.ItemsSource = _admin;

            _admin.Add(new SponsorsAdmin()
            {
                Logo = "/Resources/logo.jpg",
                Name = "Bussines",
                Description = "SomeNiGres"
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

        private void EditSponsorsAdmin(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new editsponsors_admin());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new editsponsors_admin());
        }
    }
}
