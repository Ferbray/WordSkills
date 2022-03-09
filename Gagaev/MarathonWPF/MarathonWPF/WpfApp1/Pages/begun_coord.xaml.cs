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
    /// Логика взаимодействия для begun_coord.xaml
    /// </summary>
    public partial class begun_coord : Page
    {
        private ObservableCollection<BegunCoordinator> _begun = new ObservableCollection<BegunCoordinator>();
        private int count_search = 0;
        public begun_coord()
        {
            InitializeComponent();
            BegunsCordGrid.IsReadOnly = true;
            BegunsCordGrid.CanUserResizeColumns = true;
            BegunsCordGrid.CanUserResizeRows = true;
            BegunsCordGrid.ItemsSource = _begun;
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
            total_runners.Text = (++count_search).ToString();
            _begun.Add(new BegunCoordinator()
            {
                Name = "Ivan",
                Family = "Gagaev",
                Email = "123456789123456789123456",
                Status = "Bussines"
            });
        }
    }
}
