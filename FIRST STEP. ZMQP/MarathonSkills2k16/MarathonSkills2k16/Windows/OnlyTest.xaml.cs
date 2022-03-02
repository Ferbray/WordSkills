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

namespace MarathonSkills2k16.Windows
{
    /// <summary>
    /// Логика взаимодействия для OnlyTest.xaml
    /// </summary>
    public partial class OnlyTest : Window
    {
        public OnlyTest()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnlyTest onlyTest = this;
            onlyTest.Close();
            Manager.MainFrame.Navigate(new Pages.ForRunners());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OnlyTest onlyTest = this;
            onlyTest.Close();
            Manager.MainFrame.Navigate(new Pages.ForCoordinator());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            OnlyTest onlyTest = this;
            onlyTest.Close();
            Manager.MainFrame.Navigate(new Pages.ForAdmin());
        }
    }
}
