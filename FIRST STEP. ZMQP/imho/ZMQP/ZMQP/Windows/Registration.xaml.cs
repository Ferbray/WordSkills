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
            Login.MaxLength = 25;
            Email.MaxLength = 25;
            PassBoxVisibility.MaxLength = 25;
            PassBoxNoVisibility.MaxLength = 25;
            PassBoxVisibilityDouble.MaxLength = 25;
            PassBoxNoVisibilityDouble.MaxLength = 25;
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
                
                PassBoxVisibility.Visibility = Visibility.Visible;
                PassBoxNoVisibility.Visibility = Visibility.Collapsed;
                PassBoxVisibility.Text = PassBoxNoVisibility.Password;

                PassBoxButtonVisibility.Source = imageBitmap2;

                PassBoxVisibilityDouble.Visibility = Visibility.Visible;
                PassBoxNoVisibilityDouble.Visibility = Visibility.Collapsed;
                PassBoxVisibilityDouble.Text = PassBoxNoVisibilityDouble.Password;

                PassBoxButtonVisibilityDouble.Source = imageBitmap2;
            }
        }

        private bool CheckLengthField(bool check_field)
        {
            bool flag_visibility = false;

            if (
                (PassBoxVisibility.Visibility == Visibility.Visible && PassBoxVisibility.Text.Length >= 5 && PassBoxVisibilityDouble.Text.Length >= 5) ||
                (PassBoxVisibility.Visibility == Visibility.Collapsed && PassBoxNoVisibility.Password.Length >= 5 && PassBoxNoVisibilityDouble.Password.Length >= 5))
            {
                flag_visibility = true;
            }

            if (
                (Login.Text.Length >= 5 || Login.Text == "GIS" || Login.Text == "zmqp") &&
                Email.Text.Length >= 5 &&
                flag_visibility &&
                check_field)
            {
                error_reg.Text = "";
                return true;
            }

            if (check_field)
                error_reg.Text = "Все поля должны быть больше 5, \n но меньше 16 символов";
            return false;

        }

        private bool CheckIdenticalField(bool check_field)
        {
            if (
                (PassBoxVisibility.Text == PassBoxVisibilityDouble.Text ||
                PassBoxNoVisibility.Password == PassBoxNoVisibilityDouble.Password) &&
                check_field)
            {
                error_reg.Text = "";
                return true;
            }

            if (check_field)
                error_reg.Text = "Поля паролей не схожи";
            return false;
        }

        private bool CheckIdenticalUser(bool check_field)
        {
            if (!check_field) return false;

            using (UserContext db = new UserContext())
            {
                var users = db.Users;
                foreach (User u in users)
                {
                    if (u.Login == Login.Text || u.Email == Email.Text)
                    {
                        error_reg.Text = (u.Login == Login.Text) ? 
                            "Уже есть пользователь с логином \n" + Login.Text : 
                            "Уже есть пользователь с логином\n" + Email.Text;
                        return false;
                    }
                }
                error_reg.Text = "";
                return true;
            }
        }

        private void RegistrateNewUser(object sender, MouseButtonEventArgs e)
        {
            bool check_field = CheckLengthField(true);
            check_field = CheckIdenticalField(check_field);
            check_field = CheckIdenticalUser(check_field);

            if (check_field == true)
            {
                using (UserContext db = new UserContext())
                {
                    User user1 = new User
                    {
                        Login = Login.Text,
                        Email = Email.Text,
                        Password = (PassBoxVisibility.Visibility == Visibility.Visible) ? PassBoxVisibility.Text : PassBoxNoVisibility.Password,
                        isAdmin = 0
                    };
                    db.Users.Add(user1);
                    db.SaveChanges();
                    Windows.Login login = new Windows.Login();
                    this.Close();
                    login.Show();
                }
            }
        }
    }
}
