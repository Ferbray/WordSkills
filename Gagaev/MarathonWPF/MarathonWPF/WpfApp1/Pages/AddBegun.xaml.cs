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
    /// Логика взаимодействия для AddBegun.xaml
    /// </summary>
    public partial class AddBegun : Page
    {
        public AddBegun()
        {
            InitializeComponent();
            RegName.MaxLength = 24;
            RegFamily.MaxLength = 24;
            RegPass.MaxLength = 24;
            RegPassAgree.MaxLength = 24;
        }

        private void BackEdit(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Home());
        }

        private void SaveEdit(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void RegPass_KeyDown(object sender, KeyEventArgs e)
        {
            Random random = new Random();
            string random_char = "ABCDEFGHIJKLMNOPQVZX123456";
            RegPass.PasswordChar += random_char[random.Next(0, random_char.Length)];
        }

        private void RegPassAgree_KeyDown(object sender, KeyEventArgs e)
        {
            Random random = new Random();
            string random_char2 = "ABCDEFGHIJKLMNOPQVZX123456";
            RegPassAgree.PasswordChar += random_char2[random.Next(0, random_char2.Length)];
        }
    }
}
