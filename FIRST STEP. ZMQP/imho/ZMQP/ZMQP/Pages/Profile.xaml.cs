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

namespace ZMQP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
        }


        private void ProfileNickName(object sender, EventArgs e)
        {
            (sender as TextBlock).Text = Classes.DataBase.Login;
        }

        private void ProfileIDs(object sender, EventArgs e)
        {
            (sender as TextBlock).Text = "#" + Classes.DataBase.ID.ToString();

        private void GameProfileBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.Library());
        }

        private void FriendProfileBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.Friends());
        }

        private void AchivProfileBar_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AboutProfileBar_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void EditProfileBar_MouseDown(object sender, MouseButtonEventArgs e)
        {


        }
    }
}
