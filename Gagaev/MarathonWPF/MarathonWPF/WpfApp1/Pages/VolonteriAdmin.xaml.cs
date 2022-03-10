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
    /// Логика взаимодействия для VolonteriAdmin.xaml
    /// </summary>
    public partial class VolonteriAdmin : Page
    {
        private ObservableCollection<VolonteriAdminCS> _volonters = new ObservableCollection<VolonteriAdminCS>();
        public VolonteriAdmin()
        {
            InitializeComponent();
            VolonteriAdminGrid.IsReadOnly = true;
            VolonteriAdminGrid.CanUserResizeColumns = true;
            VolonteriAdminGrid.CanUserResizeRows = true;
            VolonteriAdminGrid.ItemsSource = _volonters;
        }

        private void Cancel_Pay(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Home());
        }

        private void EditBegunCoord(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ControlBegun());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            total_runners.Text = (Int32.Parse(total_runners.Text) + 1).ToString();
            _volonters.Add(new VolonteriAdminCS()
            {
                Family = "Gagaev",
                Name = "Ivan",
                Country = "gggg",
                Gender = "m"
            });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoadVolonters());
        }
    }
}
