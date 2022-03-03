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
    /// Логика взаимодействия для thanks_donate.xaml
    /// </summary>
    public partial class thanks_donate : Page
    {
        public thanks_donate()
        {
            InitializeComponent();
        }
        private void Cancel_Pay(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Home());
        }
    }
}
