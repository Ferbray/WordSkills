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
    /// Логика взаимодействия для Sertificat.xaml
    /// </summary>
    public partial class Sertificat : Page
    {
        public Sertificat()
        {
            InitializeComponent();
        }

        private void Cancel_Pay(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Home());
        }
    }
}
