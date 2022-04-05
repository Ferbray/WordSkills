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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
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

        private Tuple<int, string, int, int, int, string> CheckUserField(bool check_field)
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
                        return Tuple.Create(user.ID, user.Login, user.isAdmin, user.isBan, user.isMute, user.Photo);
                    }
                }
                error_find.Text = check_field ? "Такого пользователя не существует\nВозможно вы ошиблись" : error_find.Text;
                return Tuple.Create(-1, "", -1, -1, -1, "");
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
            (int id, string login, int isadmin, int isban, int ismute, string photo) = CheckUserField(check_field);

            if (id > 0 && isadmin == 0 && isban == 0)
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
            (int id, string login, int isadmin, int isban, int ismute, string photo) = CheckUserField(check_field);

            if (id > 0 && isadmin == 0 && isban == 1)
                UnAndBanUser(id, false);

            else if (isadmin > 0)
                error_find.Text = "Вы пытаетесь разбанить админа";

            else if (isban == 0)
                error_find.Text = "Пользователь не в бане";
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
                        error_find.Text = check_mute ? $"Вы замутили {FindBox.Text}" : $"Вы размутили {FindBox.Text}";
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
            (int id, string login, int isadmin, int isban, int ismute, string photo) = CheckUserField(check_field);

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
            (int id, string login, int isadmin, int isban, int ismute, string photo) = CheckUserField(check_field);

            if (id > 0 && isadmin == 0 && ismute == 1)
                UnAndMuteUser(id, false);

            else if (isadmin > 0)
                error_find.Text = "Вы пытаетесь размутить админа";

            else if (ismute == 0)
                error_find.Text = "Пользователь не в муте";
        }

        private void InviteFriend_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void EditProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void FindUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            error_find.Foreground = new SolidColorBrush(Colors.Red);
            bool check_field = CheckIsAdmin(true);
            check_field = CheckErrorField(true);
            (int id, string login, int isadmin, int isban, int ismute, string photo) = CheckUserField(check_field);

            if (id > 0)
            {
                Image img = new Image()
                {
                    Source = new BitmapImage(new Uri("/" + photo, UriKind.Relative)),
                    Width = 150,
                    Height = 150
                };

                img.Clip = new EllipseGeometry()
                {
                    Center = new Point(75, 75),
                    RadiusX = 75,
                    RadiusY = 75
                };

                ProfileUser.Children.Add(img);
                Grid.SetRow(img, 0);

                TextBlock text_id = new TextBlock()
                {
                    Text = $"#{id}",
                    Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF8E8E8E"),
                    FontSize = 24,
                    Margin = new Thickness(0, 0, 20, 0),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Right,
                };

                TextBlock text_login = new TextBlock()
                {
                    Text = $"{login}",
                    Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF454545"),
                    FontSize = 22,
                    FontWeight = FontWeights.Bold,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                };

                Grid_IdAndLogin.Children.Add(text_id);
                Grid.SetColumn(text_id, 0);
                Grid_IdAndLogin.Children.Add(text_login);
                Grid.SetColumn(text_login, 1);

                TextBlock text_online = new TextBlock()
                {
                    Text = "В сети",
                    Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF00611C"),
                    FontSize = 18,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };

                ProfileUser.Children.Add(text_online);
                Grid.SetRow(text_online, 2);

                Border friend_border = new Border
                {
                    Style = (Style)FindResource("ButtonStyle"),
                    Width = 150,
                    Height = 30,
                    BorderThickness = new Thickness(1),
                    HorizontalAlignment = HorizontalAlignment.Center,
                };

                TextBlock friend_button = new TextBlock
                {
                    Text = "Добавить в друзья",
                    Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF949494"),
                    FontSize = 14,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                friend_border.Child = friend_button;
                friend_border.MouseDown += InviteFriend_MouseDown;
                ProfileUser.Children.Add(friend_border);
                Grid.SetRow(friend_border, 3);

                if (isadmin == 0)
                {
                    Border edit_border = new Border
                    {
                        Style = (Style)FindResource("ButtonStyle"),
                        Width = 150,
                        Height = 30,
                        BorderThickness = new Thickness(1),
                        HorizontalAlignment = HorizontalAlignment.Center,
                    };

                    TextBlock edit_button = new TextBlock
                    {
                        Text = "Редактировать",
                        FontSize = 14,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF949494"),
                    };
                    edit_border.Child = edit_button;
                    edit_border.MouseDown += EditProfile_MouseDown;
                    ProfileUser.Children.Add(edit_border);
                    Grid.SetRow(edit_border, 4);

                    Border ban_border = new Border
                    {
                        Style = (Style)FindResource("ButtonStyle"),
                        Width = 150,
                        Height = 30,
                        BorderThickness = new Thickness(1),
                        HorizontalAlignment = HorizontalAlignment.Center,
                    };

                    TextBlock ban_button = new TextBlock
                    {
                        Text = isban == 0 ? "Забанить" : "Разбанить",
                        FontSize = 14,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF949494"),
                    };

                    ban_border.Child = ban_button;

                    if (isban == 0)
                        ban_border.MouseDown += BanUser_MouseDown;
                    else
                        ban_border.MouseDown += UnBanUser_MouseDown;

                    ProfileUser.Children.Add(ban_border);
                    Grid.SetRow(ban_border, 5);

                    Border mute_border = new Border
                    {
                        Style = (Style)FindResource("ButtonStyle"),
                        Width = 150,
                        Height = 30,
                        BorderThickness = new Thickness(1),
                        HorizontalAlignment = HorizontalAlignment.Center,
                    };

                    TextBlock mute_button = new TextBlock
                    {
                        Text = ismute == 0 ? "Замутить" : "Размутить",
                        FontSize = 14,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF949494"),
                    };

                    mute_border.Child = mute_button;

                    if (ismute == 0)
                        mute_border.MouseDown += MuteUser_MouseDown;
                    else
                        mute_border.MouseDown += UnMuteUser_MouseDown;

                    ProfileUser.Children.Add(mute_border);
                    Grid.SetRow(mute_border, 6);
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
