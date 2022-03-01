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
    /// Логика взаимодействия для RegBegun.xaml
    /// </summary>
    public partial class RegBegun : Page
    {
        public RegBegun()
        {
            InitializeComponent();
            subtitle.Text = "Пожалуйста заполните всю информацию, чтобы зарегистрироваться в качестве\n\t\t\t\tбегуна";
            RegEmail.MaxLength = 16;
            RegName.MaxLength = 16;
            RegFamily.MaxLength = 16;
            RegPass.MaxLength = 16;
            RegPassAgree.MaxLength = 16;
            combo_gender.Items.Add("Мужской");
            combo_gender.Items.Add("Женский");
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            Random random = new Random();
            string random_char = "ABCDEFGHIJKLMNOPQVZX123456";
            RegPass.PasswordChar += random_char[random.Next(0, random_char.Length)];
        }

        private void PasswordBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            Random random2 = new Random();
            string random_char2 = "ABCDEFGHIJKLMNOPQVZX123456";
            RegPassAgree.PasswordChar += random_char2[random2.Next(0, random_char2.Length)];
        }
    }
}
