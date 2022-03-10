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
    /// Логика взаимодействия для begun_admin.xaml
    /// </summary>
    public partial class begun_admin : Page
    {
        private ObservableCollection<BegunAdmin> _admin = new ObservableCollection<BegunAdmin>();
        public begun_admin()
        {
            InitializeComponent();
            BegunsAdminGrid.IsReadOnly = true;
            BegunsAdminGrid.ItemsSource = _admin;
            BegunsAdminGrid.CanUserResizeColumns = true;
            BegunsAdminGrid.CanUserResizeRows = true;
        }

        private void Cancel_Pay(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Home());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            total_runners.Text = (Int32.Parse(total_runners.Text)+1).ToString();
            _admin.Add(new BegunAdmin()
            {
                Name = "Ivan",
                Family = "Gagaev",
                Email = "gggg@gggg.gg",
                Role = "admin"
            });
        }

        private void EditBegunCoord(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new BegunEditAdmin());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddBegun());
        }
    }
}
