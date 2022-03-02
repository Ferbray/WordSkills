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
    /// Логика взаимодействия для SponsorsBegun.xaml
    /// </summary>
    public partial class SponsorsBegun : Page
    {
        public SponsorsBegun()
        {
            InitializeComponent();
            combo_begun.Items.Add("Дани Гер Лавашов");
            combo_begun.Items.Add("Лена Янач");
            combo_begun.Items.Add("Яша Лава Головач");
        }
        private void info_window(object sender, RoutedEventArgs e)
        {
            Windows.AboutFond wd = new Windows.AboutFond();
            wd.Show();
        }

        private void Cancel_Pay(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
