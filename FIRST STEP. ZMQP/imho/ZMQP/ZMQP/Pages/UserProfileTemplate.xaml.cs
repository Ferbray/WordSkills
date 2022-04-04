using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using ZMQP.Classes;

namespace ZMQP.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserProfileTemplate.xaml
    /// </summary>
    public partial class UserProfileTemplate : Page
    {
        public UserProfileTemplate()
        {
            InitializeComponent();
        }

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

        private void LoadDescription(object sender, RoutedEventArgs e)
        {
            (sender as TextBlock).Text = NetWork.GetDescription(Hndr.friendid.ToString());
        }

        private void ProfileNickName(object sender, RoutedEventArgs e)
        {
            (sender as TextBlock).Text = NetWork.GetLogin(Hndr.friendid);
        }

        private void ProfileIDs(object sender, RoutedEventArgs e)
        {
            (sender as TextBlock).Text = "#" + Classes.Hndr.friendid.ToString();
        }


        private void LoadProfilePhoto(object sender, RoutedEventArgs e)
        {
            var binaryData = Convert.FromBase64String(NetWork.GetProfileImage(Hndr.friendid.ToString()));
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.EndInit();

            (sender as Image).Source = bi;
        }

        private void SetStatusProfile(object sender, RoutedEventArgs e)
        {
            (sender as TextBlock).Text = Classes.Getter.GetFriendStatus(Classes.Hndr.friendid) == 1 ? "Онлайн" : "Офлайн";
            (sender as TextBlock).Foreground = Classes.Getter.GetFriendStatus(Classes.Hndr.friendid) == 1 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Gray);
        }
    }
}
