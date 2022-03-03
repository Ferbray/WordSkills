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
    /// Логика взаимодействия для RegMarathon.xaml
    /// </summary>
    public partial class RegMarathon : Page
    {
        public RegMarathon()
        {
            InitializeComponent();
            subtitle.Text = "Пожалуйста заполните всю информацию, чтобы зарегистрироваться на Skills\n" +
                "      Marathon 2016 проводимом в Москве. Russia. С вами свяжутся после\n\t" +
                "    регистрации для уточнения оплаты и другой информации";
            combo_placedonate.Items.Add("Фонд кошек");
            combo_placedonate.Items.Add("Фонд бездомных");
            combo_placedonate.Items.Add("Фонд собак");
        }
        private void Cancel_Pay(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new menu_beguna());
        }

        private void info_window(object sender, RoutedEventArgs e)
        {
            Windows.AboutFond wd = new Windows.AboutFond();
            wd.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new thanks_reg());
        }
    }
}
