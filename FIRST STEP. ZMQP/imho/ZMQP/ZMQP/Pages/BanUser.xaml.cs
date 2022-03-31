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
    /// Логика взаимодействия для BanUser.xaml
    /// </summary>
    public partial class BanUser : Page
    {
        public BanUser()
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
                        return Tuple.Create(user.ID, user.isAdmin, user.isBan);
                    }
                }
                error_find.Text = check_field ? "Такого пользователя не существует\nВозможно вы ошиблись" : error_find.Text;
                return Tuple.Create(-1, -1, -1);
            }
        }

        private void UnAndBanUser(int id, bool check_ban)
        {
            using (UserContext db = new UserContext())
            {
                var users = db.Users;

                foreach (var user in users)
                {
                    if (user.ID == id)
                    {
                        error_find.Text = check_ban ? $"Вы забанили {FindBox.Text}" : $"Вы разбанили {FindBox.Text}";
                        error_find.Foreground = new SolidColorBrush(Colors.Green);
                        user.isBan = check_ban ? 1 : 0;
                        break;
                    }
                }
                db.SaveChanges();
            }
        }

        private void BanUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            error_find.Foreground = new SolidColorBrush(Colors.Red);
            bool check_field = CheckIsAdmin(true);
            check_field = CheckErrorField(true);
            (int id, int isadmin, int isban) = CheckUserField(check_field);

            if (id >= 0 && isadmin == 0 && isban == 0)
                UnAndBanUser(id, true);

            else if (isadmin > 0)
                error_find.Text = "Вы пытаетесь забанить админа";

            else if (isban == 1)
                error_find.Text = "Пользователь в бане";
        }

        private void UnBanUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            error_find.Foreground = new SolidColorBrush(Colors.Red);
            bool check_field = CheckIsAdmin(true);
            check_field = CheckErrorField(true);
            (int id, int isadmin, int isban) = CheckUserField(check_field);

            if (id >= 0 && isadmin == 0 && isban == 1)
                UnAndBanUser(id, false);

            else if (isadmin > 0)
                error_find.Text = "Вы пытаетесь разбанить админа";

            else if (isban == 0)
                error_find.Text = "Пользователь не в бане";
        }

        private void FindUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                var users = db.Users;

                foreach (var user in users)
                {
                    if (user.ID == Classes.Hndr.id & user.isAdmin == 1)
                    {

                    }
                }
            }
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
