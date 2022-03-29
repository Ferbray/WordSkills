using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private bool CheckExist()
        {
            bool isExist = false;

            using (UserContext db = new UserContext())
            {
                
                var users = db.Users.ToList();

                foreach (var user in users)
                {
                    if (user.Login == Login.Text || user.Email == Email.Text)
                    {
                        isExist = true;
                        break;
                    }
                }

            }

            return isExist;
        }

        private bool CheckLength()
        {
            bool isRight = true;

            if (Login.Text.Length < 5 || Email.Text.Length < 5 || PassBoxNoVisibility.Password.Length < 5 || PassBoxVisibility.Text.Length < 5)
            {
                isRight = false;
            }

            return isRight;
        }

        private bool IdenticalPassword()
        {
            bool isIdentity = false;

            if (PassBoxNoVisibility.Visibility == Visibility.Visible & PassBoxNoVisibilityDouble.Visibility == Visibility.Visible)
            {
                if (PassBoxNoVisibility.Password == PassBoxNoVisibilityDouble.Password) isIdentity = true;
            }

            else if (PassBoxNoVisibility.Visibility == Visibility.Visible & PassBoxNoVisibilityDouble.Visibility == Visibility.Collapsed)
            {
                if (PassBoxNoVisibility.Password == PassBoxVisibilityDouble.Text) isIdentity = true;
            }

            else if (PassBoxNoVisibility.Visibility == Visibility.Collapsed & PassBoxNoVisibilityDouble.Visibility == Visibility.Visible)
            {
                if (PassBoxVisibility.Text == PassBoxNoVisibilityDouble.Password) isIdentity = true;
            }

            else if(PassBoxNoVisibility.Visibility == Visibility.Collapsed & PassBoxNoVisibilityDouble.Visibility == Visibility.Collapsed)
            {
                if (PassBoxVisibility.Text == PassBoxVisibilityDouble.Text) isIdentity = true;
            }

            return isIdentity;
        }

        private bool CheckEmail(string email)
        {
            bool isTrue = true;

            if (string.IsNullOrWhiteSpace(email))
            {
                isTrue = false;
            }

            if (!email.Contains("@") || email.IndexOf("@") >= email.Length-1)
            {
                isTrue = false;
            }

            return isTrue;
        }


        private void RegistrateNewUser(object sender, MouseButtonEventArgs e)
        {


            using (UserContext db = new UserContext())
            {
                bool isExist = CheckExist();
                bool isRight = CheckLength();
                var users = db.Users.ToList();

               
                if (!isRight)
                {
                    IdentityError.Text = "Все поля должны быть более 5 символов";
                    IdentityError.Visibility = Visibility.Visible;
                }

                else if (!IdenticalPassword())
                {
                    IdentityError.Text = "Пароли не совпадают";
                    IdentityError.Visibility = Visibility.Visible;
                }

                else if (!CheckEmail(Email.Text))
                {
                    IdentityError.Text = "Неверный ввод Email";
                    IdentityError.Visibility = Visibility.Visible;
                }

                else
                {
                    if (!isExist)
                    {
                        User user1 = new User
                        {
                            Login = Login.Text,
                            Email = Email.Text,
                            Password = (PassBoxNoVisibility.Visibility == Visibility) ? PassBoxNoVisibility.Password : PassBoxVisibility.Text
                        };
                        db.Users.Add(user1);
                        db.SaveChanges();


                        Windows.Login login = new Windows.Login();
                        this.Close();
                        login.Show();
                    }

                    else
                    {
                        IdentityError.Text = "Такой аккаунт существует";
                        IdentityError.Visibility = Visibility.Visible;
                    }
                }
                
            }

        }
    }
}
