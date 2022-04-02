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

namespace ZMQP.Pages
{
    /// <summary>
    /// Логика взаимодействия для MuteUser.xaml
    /// </summary>
    public partial class MuteUser : Page
    {
        public MuteUser()
        {
            InitializeComponent();
        }

        private bool CheckIsAdmin(bool check_field)
        {
            using (UserContext db = new UserContext())
            {
                var users = db.Users;

                foreach (var user in users)
                {
                    if (check_field & user.ID == Classes.Hndr.id & user.isAdmin == 1)
                    {
                        error_find.Text = "";
                        return true;
                    }
                }
            }
            error_find.Text = "Вы не являетесь админом";
            return false;
        }

        private bool CheckErrorField(bool check_field)
        {
            if (check_field && FindBox.Text.Length > 0)
            {
                error_find.Text = "";
                return true;
            }
            error_find.Text = "Поле пустое";
            return false;
        }

        private Tuple<int, int, int> CheckUserField(bool check_field)
        {
            using (UserContext db = new UserContext())
            {
                var users = db.Users;

                foreach (var user in users)
                {
                    if (check_field &&
                    (FindBox.Text == user.ID.ToString() ||
                    FindBox.Text == user.Login ||
                    FindBox.Text == user.Email))
                    {
                        error_find.Text = "";
                        return Tuple.Create(user.ID, user.isAdmin, user.isMute);
                    }
                }
                error_find.Text = check_field ? "Такого пользователя не существует\nВозможно вы ошиблись" : error_find.Text;
                return Tuple.Create(-1, -1, -1);
            }
        }

        private void UnAndMuteUser(int id, bool check_mute)
        {
            using (UserContext db = new UserContext())
            {
                var users = db.Users;

                foreach (var user in users)
                {
                    if (user.ID == id)
                    {
                        error_find.Text = check_mute ? $"Вы замутили {FindBox.Text}": $"Вы размутили {FindBox.Text}";
                        error_find.Foreground = new SolidColorBrush(Colors.Green);
                        user.isMute = check_mute ? 1 : 0;
                        break;
                    }
                }
                db.SaveChanges();
            }
        }

        private void MuteUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            error_find.Foreground = new SolidColorBrush(Colors.Red);
            bool check_field = CheckIsAdmin(true);
            check_field = CheckErrorField(true);
            (int id, int isadmin, int ismute) = CheckUserField(check_field);

            if (id > 0 && isadmin == 0 && ismute == 0)
                UnAndMuteUser(id, true);

            else if (isadmin > 0)
                error_find.Text = "Вы пытаетесь замутить админа";

            else if (ismute == 1)
                error_find.Text = "Пользователь в муте";
        }

        private void UnMuteUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            error_find.Foreground = new SolidColorBrush(Colors.Red);
            bool check_field = CheckIsAdmin(true);
            check_field = CheckErrorField(true);
            (int id, int isadmin, int ismute) = CheckUserField(check_field);

            if (id > 0 && isadmin == 0 && ismute == 1)
                UnAndMuteUser(id, false);

            else if (isadmin > 0)
                error_find.Text = "Вы пытаетесь размутить админа";

            else if (ismute == 0)
                error_find.Text = "Пользователь не в муте";
        }

        private void FindUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void FindBox_GotFocus(object sender, RoutedEventArgs e)
        {
            text_desc.Visibility = Visibility.Hidden;
        }

        private void FindBox_LostFocus(object sender, RoutedEventArgs e)
        {
            text_desc.Visibility = Visibility.Visible;
        }
    }
}
