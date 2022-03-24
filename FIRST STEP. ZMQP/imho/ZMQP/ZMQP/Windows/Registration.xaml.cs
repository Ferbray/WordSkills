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
using System.Windows.Shapes;
using ZMQP.Classes;

namespace ZMQP.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();

        }

        private void ToolBarButtonClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ToolBarButtonMin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Windows.Login login = new Windows.Login();
            login.Show();
            this.Close();
        }

        private void PassBoxButtonVisibility_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PassBoxVisibility.Visibility == Visibility.Visible)
            {
                String stringPath = "/Resources/eyeNo.png";
                Uri imageUri = new Uri(stringPath, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);

                PassBoxVisibility.Visibility = Visibility.Collapsed;
                PassBoxNoVisibility.Visibility = Visibility.Visible;
                PassBoxNoVisibility.Password = PassBoxVisibility.Text;

                PassBoxButtonVisibility.Source = imageBitmap;
            }

            else
            {
                String stringPath2 = "/Resources/eye.png";
                Uri imageUri2 = new Uri(stringPath2, UriKind.Relative);
                BitmapImage imageBitmap2 = new BitmapImage(imageUri2);
                
                PassBoxVisibility.Visibility = Visibility.Visible;
                PassBoxNoVisibility.Visibility = Visibility.Collapsed;
                PassBoxVisibility.Text = PassBoxNoVisibility.Password;

                PassBoxButtonVisibility.Source = imageBitmap2;
            }
        }

        private void PassBoxButtonVisibilityDouble_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PassBoxVisibilityDouble.Visibility == Visibility.Visible)
            {
                String stringPath = "/Resources/eyeNo.png";
                Uri imageUri = new Uri(stringPath, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);

                PassBoxVisibilityDouble.Visibility = Visibility.Hidden;
                PassBoxNoVisibilityDouble.Visibility = Visibility.Visible;
                PassBoxNoVisibilityDouble.Password = PassBoxVisibilityDouble.Text;


                PassBoxButtonVisibilityDouble.Source = imageBitmap;
            }

            else
            {
                String stringPath2 = "/Resources/eye.png";
                Uri imageUri2 = new Uri(stringPath2, UriKind.Relative);
                BitmapImage imageBitmap2 = new BitmapImage(imageUri2);

                PassBoxVisibilityDouble.Visibility = Visibility.Visible;
                PassBoxNoVisibilityDouble.Visibility = Visibility.Collapsed;
                PassBoxVisibilityDouble.Text = PassBoxNoVisibilityDouble.Password;

                PassBoxButtonVisibilityDouble.Source = imageBitmap2;
            }
        }

        private void RegistrateNewUser(object sender, MouseButtonEventArgs e)
        {
            using (UserContext db = new UserContext())
            {

                User user1 = new User {ID = 1, Login = "qwerty", Email = "zxc@mail.ru", Password = "12345", isModerator = 0 };
                db.Users.Add(user1);
                db.SaveChanges();


                Windows.Login login = new Windows.Login();
                this.Close();
                login.Show();
            }

        }
    }
}
