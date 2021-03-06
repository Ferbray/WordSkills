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
using System.Windows.Shapes;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для AboutLogin.xaml
    /// </summary>
    public partial class AboutLogin : Window
    {
        public AboutLogin()
        {
            InitializeComponent();
            subtitle.Text = "Под каким пользователем вы хотите\n\tвойти в систему?";
        }
        private void Close_Window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Manager.MainFrame.Navigate(new Pages.menu_beguna());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            Manager.MainFrame.Navigate(new Pages.menu_coord());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
            Manager.MainFrame.Navigate(new Pages.menu_admin());
        }
    }
}
