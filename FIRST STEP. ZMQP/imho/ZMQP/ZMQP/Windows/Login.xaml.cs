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

namespace ZMQP.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            LoginBox.MaxLength = 25;
            PassBoxVisibility.MaxLength = 25;
            PassBoxNoVisibility.MaxLength = 25;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ToolBarButtonClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ToolBarButtonMin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Windows.Registration Registration = new Windows.Registration();
            Registration.Show();
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

        private bool CheckLengthField(bool check_field)
        {
            bool flag_visibility = false;

            if (
                (PassBoxVisibility.Visibility == Visibility.Visible && PassBoxVisibility.Text.Length >= 5) ||
                (PassBoxVisibility.Visibility == Visibility.Collapsed && PassBoxNoVisibility.Password.Length >= 5))
            {
                flag_visibility = true;
            }

            if (
                (LoginBox.Text.Length >= 5 || LoginBox.Text == "GIS" || LoginBox.Text == "zmqp") &&
                flag_visibility &&
                check_field)
            {
                error_entry.Text = "";
                return true;
            }    
            if (check_field)
                error_entry.Text = "Все поля должны быть больше 5, \n но меньше 16 символов";
            return false;

        }

        private Tuple<int, string,int> CheckIndenticalUser(bool check_field)
        {
            using (UserContext db = new UserContext())
            {
                var users = db.Users;
                foreach (User u in users)
                {
                    if (
                        (LoginBox.Text == u.ID.ToString() || LoginBox.Text == u.Login || LoginBox.Text == u.Email) && 
                        (PassBoxVisibility.Text == u.Password || PassBoxNoVisibility.Password == u.Password) && 
                        check_field)
                    {
                        error_entry.Text = "";
                        return Tuple.Create(u.ID, u.Login, u.isBan);
                    }
                }
                if (check_field)
                    error_entry.Text = "Не верный логин или пароль";
                return Tuple.Create(-1, "", -1);
            }
        }

        private void Verification_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bool check_field = CheckLengthField(true);
            (int id, string login, int isBan) = CheckIndenticalUser(check_field);

            if (id > 0 & login.Length > 0 & isBan == 0)
            {
                using (UserContext db = new UserContext())
                {
                    Classes.Hndr.id = id;
                    Classes.Hndr.login = login;
                    Windows.ApplicationTemplate at = new Windows.ApplicationTemplate();
                    this.Close();
                    at.Show();
                }
            }

            else if(isBan == 1)
            {
                error_entry.Text = "Вы забанены на проекте ZMQP";
            }
        }
    }
}
