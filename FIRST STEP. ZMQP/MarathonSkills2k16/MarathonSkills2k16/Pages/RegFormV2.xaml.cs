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
    /// Логика взаимодействия для RegFormV2.xaml
    /// </summary>
    public partial class RegFormV2 : Page
    {
        public RegFormV2()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Windows.AboutBlog wd = new Windows.AboutBlog();
            wd.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Thanks());
        }
    }
}
