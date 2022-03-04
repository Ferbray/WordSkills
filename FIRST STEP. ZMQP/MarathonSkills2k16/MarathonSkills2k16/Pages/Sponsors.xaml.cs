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
    /// Логика взаимодействия для Sponsors.xaml
    /// </summary>
    public partial class Sponsors : Page
    {
        public Sponsors()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Windows.AboutBlog wd = new Windows.AboutBlog();
            wd.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)

        {
            Manager.MainFrame.Navigate(new ProcessingPay(name: NamePay.Text,pay: Count.Text));
        }

        private void TextBox_Initialized(object sender, EventArgs e)
        {
            (sender as TextBox).Text = "50";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Count.Text = $"${int.Parse(Count.Text.Substring(1, Count.Text.Length - 1)) + 10}";
            CountBox.Text = Count.Text.Substring(1, Count.Text.Length - 1);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if ( int.Parse(Count.Text.Substring(1, Count.Text.Length - 1)) > 0 )
            {
                Count.Text = $"${int.Parse(Count.Text.Substring(1, Count.Text.Length - 1)) - 10}";
                CountBox.Text = Count.Text.Substring(1, Count.Text.Length - 1);
            }
        }

        private void CountBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int value = int.Parse(CountBox.Text);
                if (value > 0)
                {
                    Count.Text = $"${CountBox.Text}";
                }
                else
                {
                    Count.Text = $"$0";
                }
            }

            catch
            {
                Count.Text = $"$0";
            }
        }
    }
}
