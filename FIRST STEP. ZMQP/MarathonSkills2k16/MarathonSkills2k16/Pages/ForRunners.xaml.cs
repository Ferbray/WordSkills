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

namespace MarathonSkills2k16.Pages
{
    /// <summary>
    /// Логика взаимодействия для ForRunners.xaml
    /// </summary>
    public partial class ForRunners : Page
    {
        public ForRunners()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RegFormV2());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Windows.Contacts window = new Windows.Contacts();
            window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MyResult());
        }

        private void Grid_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditProfile());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MySponsors());
        }
    }
}
