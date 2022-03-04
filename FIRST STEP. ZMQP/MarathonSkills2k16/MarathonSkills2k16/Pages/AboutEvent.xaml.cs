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
    /// Логика взаимодействия для AboutEvent.xaml
    /// </summary>
    public partial class AboutEvent : Page
    {
        public AboutEvent()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MarathonInfo());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new BMICalc());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new BMRCalc());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new HowLong());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ListOrganization());
        }
    }
}
