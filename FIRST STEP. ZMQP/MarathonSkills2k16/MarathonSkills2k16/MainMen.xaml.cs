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

namespace MarathonSkills2k16
{
    /// <summary>
    /// Логика взаимодействия для MainMen.xaml
    /// </summary>
    public partial class MainMen : Page
    {
        public MainMen()
        {
            InitializeComponent();
        }

        private void TextBlock_Initialized(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string whatsDay = dt.ToString("dddd d MMMM yyyy");
            (sender as TextBlock).Text = $"{whatsDay}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Template());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AuthForm());
        }
    }

}
