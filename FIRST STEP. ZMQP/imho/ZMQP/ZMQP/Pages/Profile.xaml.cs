using Microsoft.Win32;
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
using ZMQP.Classes;
using ZMQP.Windows;
using System.IO;

namespace ZMQP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    /// 
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
        }


        private void ProfileNickName(object sender, EventArgs e)
        {
           (sender as TextBlock).Text = NetWork.GetLogin(Hndr.id);
        }

        private void ProfileIDs(object sender, EventArgs e)
        {
           //(sender as TextBlock).Text = "#" + Classes.Hndr.id.ToString();
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

        private void EditProfileBar_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Edit.Visibility = Visibility.Hidden;
            SaveChanges.Visibility = Visibility.Visible;
            EditProfileAvatar.Visibility = Visibility.Visible;
            ProfilePhoto.Visibility = Visibility.Hidden;
            ProfileName.Visibility = Visibility.Hidden;
            EditLogin.Text = ProfileName.Text;
            EditLogin.Visibility = Visibility.Visible;
            ProfileDescription.Visibility = Visibility.Hidden;
            EditDescription.Text = ProfileDescription.Text;
            EditDescription.Visibility = Visibility.Visible;
            
        }

        private void LoadDescription(object sender, RoutedEventArgs e)
        {
            (sender as TextBlock).Text = NetWork.GetDescription(Hndr.id.ToString());
        }

        private void LoadProfilePhoto(object sender, RoutedEventArgs e)
        {
            var binaryData = Convert.FromBase64String(Hndr.photo);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.EndInit();

            (sender as Image).Source = bi;
        }

        private bool isSmallLength()
        {
            if (EditLogin.Text.Length < 5)
            {
                error_change.Text = "Длина логина должна быть более 5 символов";
                return true;
            }

            return false;

        }

        private void Save()
        {
            NetWork.SaveChanges(Hndr.photo, Hndr.id, EditLogin.Text, EditDescription.Text);
            //Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).BringIntoView();
        }

        private void SaveChanges_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SaveChanges.Visibility = Visibility.Hidden;
            Edit.Visibility = Visibility.Visible;
            EditProfileAvatar.Visibility = Visibility.Hidden;
            ProfilePhoto.Visibility = Visibility.Visible;
            ProfileName.Visibility = Visibility.Visible;
            EditLogin.Visibility = Visibility.Hidden;
            ProfileDescription.Visibility = Visibility.Visible;
            EditDescription.Visibility = Visibility.Hidden;

            if (!isSmallLength() && !NetWork.isExistLogin(EditLogin.Text, Hndr.login))
            {
                Save();
                this.NavigationService.Navigate(new Pages.Profile());
                
            }

        }


        private void LoadImage(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Classes.Hndr.photo = Convert.ToBase64String(File.ReadAllBytes(openFileDialog.FileName));
            }

        }
    }
}
