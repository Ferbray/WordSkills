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
                        return true;
                    }
                }
            }
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

        private void CheckUserField(bool check_field, bool check_isMute)
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
                        if (check_isMute)
                        {
                            error_find.Text = user.isMute == 1 ? "Пользователь уже в муте" : "";
                            user.isMute = 1;
                        }

                        else
                        {
                            error_find.Text = user.isMute == 1 ? "" : "Пользователь не в муте";
                            user.isMute = 0;
                        }
                        db.SaveChanges();
                    }
                }
                error_find.Text = "Такого пользователя не существует\nВозможно вы ошиблись";
            }
        }

        private void MuteUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bool check_field = CheckIsAdmin(true);
            check_field = CheckErrorField(true);
            if (check_field)
            {
                CheckUserField(check_field, true);
            }
        }

        private void UnMuteUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bool check_field = CheckIsAdmin(true);
            check_field = CheckErrorField(true);
            if (check_field)
            {
                CheckUserField(check_field, true);
            }
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
