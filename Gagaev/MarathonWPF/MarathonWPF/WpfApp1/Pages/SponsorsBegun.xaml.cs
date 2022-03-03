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
    /// Логика взаимодействия для SponsorsBegun.xaml
    /// </summary>
    public partial class SponsorsBegun : Page
    {
        public SponsorsBegun()
        {
            InitializeComponent();
            combo_begun.Items.Add("Дани Гер Лавашов");
            combo_begun.Items.Add("Лена Янач");
            combo_begun.Items.Add("Яша Лава Головач");
            input_dollars.MaxLength = 6;
        }
        private void info_window(object sender, RoutedEventArgs e)
        {
            Windows.AboutFond wd = new Windows.AboutFond();
            wd.Show();
        }

        private void Cancel_Pay(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void minus_dollar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int temp_cost = checked(int.Parse(cost_donate.Text));
                int temp_input = checked(int.Parse(input_dollars.Text));
                if (temp_cost >= 1 && temp_input >= 1)
                {
                    if (temp_cost <= 999999 && temp_input <= 999999)
                    {
                        cost_donate.Text = (temp_cost - 1).ToString();
                        input_dollars.Text = (temp_input - 1).ToString();
                    }
                }
                else
                {
                    cost_donate.Text = "10";
                    input_dollars.Text = "10";
                }
            }
            catch (FormatException)
            {
                cost_donate.Text = "10";
                input_dollars.Text = "10";
            }
        }

        private void plus_dollar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int temp_cost = checked(int.Parse(cost_donate.Text));
                int temp_input = checked(int.Parse(input_dollars.Text));
                if (temp_cost >= 0 && temp_input >= 0)
                {
                    if (temp_cost < 999999 && temp_input < 999999) {
                        cost_donate.Text = (temp_cost + 1).ToString();
                        input_dollars.Text = (temp_input + 1).ToString();
                    }
                }
                else
                {
                    cost_donate.Text = "10";
                    input_dollars.Text = "10";
                }
            }
            catch (FormatException)
            {
                cost_donate.Text = "10";
                input_dollars.Text = "10";
            }
        }

        private void input_dollars_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int temp_input = checked(int.Parse(input_dollars.Text));
                if (temp_input >= 0)
                {
                    cost_donate.Text = temp_input.ToString();
                    input_dollars.Text = temp_input.ToString();
                }
                else
                {
                    cost_donate.Text = "";
                    input_dollars.Text = "";
                }
            }
            catch (FormatException)
            {
                cost_donate.Text = "";
                input_dollars.Text = "";
            }
        }

        private void input_dollars_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int temp_input = checked(int.Parse(input_dollars.Text));
                if (temp_input >= 0)
                {
                    cost_donate.Text = temp_input.ToString();
                    input_dollars.Text = temp_input.ToString();
                }
                else
                {
                    cost_donate.Text = "";
                    input_dollars.Text = "";
                }
            }
            catch (FormatException)
            {
                cost_donate.Text = "";
                input_dollars.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new thanks_donate());
        }
    }
}
