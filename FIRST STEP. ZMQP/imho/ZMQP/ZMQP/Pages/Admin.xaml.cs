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
using ZMQP.Classes;

namespace ZMQP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void BanUser(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.BanUser());
        }

        private void MuteUser(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.MuteUser());
        }
    }
}
