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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Begun1.xaml
    /// </summary>
    public partial class Begun1 : Page
    {
        public Begun1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             Manager.MainFrame.GoBack();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.Login());
        }

        private void NewBegun_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void OldBegun_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.Login());
        }

    }
}
