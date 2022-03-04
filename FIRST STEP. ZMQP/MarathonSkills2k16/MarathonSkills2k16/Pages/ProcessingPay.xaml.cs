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
    /// Логика взаимодействия для ProcessingPay.xaml
    /// </summary>
    public partial class ProcessingPay : Page
    {
        public ProcessingPay(string name = "Иван Прудов", string pay = "$50")
        {
            InitializeComponent();
            if (pay == "")
            {
                PayCount.Text = "$50";
            }
            else
            {
                PayCount.Text = pay;
            }

            if (name == "")
            {
                NamePayer.Text = "Иван Прудов";
            }
            else
            {
                NamePayer.Text = name;
            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

    }
}
