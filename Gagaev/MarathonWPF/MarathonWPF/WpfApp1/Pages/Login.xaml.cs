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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            LoginPass.MaxLength = 16;
            LoginEmail.MaxLength = 30;
            subtitle.Text = "Пожалуйста, авторизуйтесь в системе, используя ваш адрес эл. почты \n\t\t\t\tи пароль";
        }
        
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Windows.AboutLogin wd = new Windows.AboutLogin();
            wd.Show();
        }

        public void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Home());
        }

        private void LoginPass_KeyDown(object sender, KeyEventArgs e)
        {
            Random random = new Random();
            string random_char = "ABCDEFGHIJKLMNOPQVZX123456";
            LoginPass.PasswordChar += random_char[random.Next(0, random_char.Length)];
        }
    }
}
