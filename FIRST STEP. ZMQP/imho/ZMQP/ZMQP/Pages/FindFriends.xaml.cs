using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using System.Data.Entity.Infrastructure;
using System.IO;

namespace ZMQP.Pages
{
/// <summary>
/// Логика взаимодействия для FindFriends.xaml
/// </summary>
    public partial class FindFriends : Page
    {
        public FindFriends()
        {
            InitializeComponent();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchText.Text = "";
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0)
            {
                SearchText.Text = "Search...";
            }
        }

        private int GetFriendId(string login)
        {
            using (UserContext db = new UserContext())
            {

                var users = db.Users;
                foreach (var user in users)
{
                    if (user.ID == int.Parse(login.Remove(0, 2)))
                    {
                        return user.ID;
                    }
                }
            }

            return 0;
        }


        private void SendRequest(object sender, RoutedEventArgs e)
        {
            NetWork.SendRequests(Hndr.id, int.Parse((sender as Border).Name.Remove(0, 2)));
            FindFriends ff = new FindFriends();
            this.NavigationService.Navigate(new Pages.FindFriends());
        }

        private void RemoveFriend(object sender, RoutedEventArgs e)
        {
            NetWork.RemoveFriend(Hndr.id, int.Parse((sender as Border).Name.Remove(0, 2)));
            this.NavigationService.Navigate(new Pages.FindFriends());
            
        }
        private void ShowProfile(object sender, RoutedEventArgs e)
        {
            Classes.Hndr.friendid = int.Parse((sender as TextBlock).Name.Remove(0, 2));

            this.NavigationService.Navigate(new Pages.UserProfileTemplate());
        }

        private void LoadedFriends(object sender, RoutedEventArgs e)
        {
            var users = NetWork.CountUsers().Split('|');
            
                foreach (var user in users)
                {
                if (user != "")
                {
                    if (int.Parse(user) != Classes.Hndr.id)
                    {
                        //Начальный грид
                        Grid grid = new Grid();
                        grid.Background = new SolidColorBrush(Colors.Transparent);
                        grid.Width = 250;
                        grid.Height = 150;
                        grid.Margin = new Thickness(20);
                        grid.Cursor = Cursors.Hand;
                        //Линии для грида
                        grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100) });
                        grid.RowDefinitions.Add(new RowDefinition());
                        //Размеры грида
                        //Сабгрид aka Первый грид ров
                        Grid subGrid = new Grid();
                        //Имя профиля aka Второй грид ров

                        TextBlock NickName = new TextBlock();
                        NickName.VerticalAlignment = VerticalAlignment.Center;
                        NickName.FontSize = 16;
                        NickName.FontFamily = new FontFamily("Cascadia Mono");
                        NickName.TextWrapping = TextWrapping.Wrap;
                        NickName.Style = (Style)FindResource("MenuCategory");
                        NickName.Text = NetWork.GetLogin(int.Parse(user));
                        NickName.Name = "ID" + user;
                        NickName.MouseDown += ShowProfile;
                        //колонки для грида
                        subGrid.ColumnDefinitions.Add(new ColumnDefinition());
                        subGrid.ColumnDefinitions.Add(new ColumnDefinition());
                        //Фото профиля aka Первый грид колумн

                        var binaryData = Convert.FromBase64String(Hndr.photo);
                        BitmapImage bi = new BitmapImage();
                        bi.BeginInit();
                        bi.StreamSource = new MemoryStream(binaryData);
                        bi.EndInit();
                        Image image = new Image();
                        image.Source = bi;
                        image.Width = 80;
                        image.Stretch = Stretch.Fill;
                        image.Height = 80;
                        image.HorizontalAlignment = HorizontalAlignment.Left;
                        EllipseGeometry eg = new EllipseGeometry();
                        eg.Center = new Point(40, 40);
                        eg.RadiusX = 40;
                        eg.RadiusY = 40;
                        image.Clip = eg;
                        //Второй грид колумн
                        Grid actionGrid = new Grid();

                        Grid.SetColumn(image, 0);
                        Grid.SetColumn(actionGrid, 1);
                        //Колонки для него
                        actionGrid.RowDefinitions.Add(new RowDefinition());
                        actionGrid.RowDefinitions.Add(new RowDefinition());
                        actionGrid.RowDefinitions.Add(new RowDefinition());

                        TextBlock tb = new TextBlock();
                        tb.Text = NetWork.GetStatus(int.Parse(user)) == 1 ? "Онлайн" : "Офлайн";
                        tb.VerticalAlignment = VerticalAlignment.Center;
                        tb.FontSize = 14;
                        tb.Foreground = NetWork.GetStatus(int.Parse(user)) == 1 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Gray);

                        Border messBorder = new Border();
                        messBorder.Style = (Style)FindResource("ButtonStyle");

                        TextBlock messText = new TextBlock();
                        messText.Text = "Сообщение";
                        messText.Style = (Style)FindResource("ButtonText");
                        messBorder.Child = messText;

                        Border actBorder = new Border();
                        actBorder.Style = (Style)FindResource("ButtonStyle");
                        actBorder.Name = "ID" + user;



                        TextBlock actText = new TextBlock();
                        if (NetWork.isExistingFriendship(Classes.Hndr.id, int.Parse(user)))
                        {
                            actBorder.MouseDown += RemoveFriend;
                            actText.Text = "Удалить";
                        }
                        else if (NetWork.isExistingRequest(Classes.Hndr.id, int.Parse(user)))
                        {
                            actText.Text = "Отправлено";
                        }

                        else
                        {
                            actBorder.MouseDown += SendRequest;
                            actText.Text = "Добавить";
                        }
                        actText.Style = (Style)FindResource("ButtonText");
                        actBorder.Child = actText;

                        Grid.SetRow(tb, 0);
                        Grid.SetRow(messBorder, 1);
                        Grid.SetRow(actBorder, 2);

                        Grid.SetRow(subGrid, 0);
                        grid.Children.Add(subGrid);
                        Grid.SetRow(NickName, 1);
                        grid.Children.Add(NickName);
                        Grid.SetColumn(image, 0);
                        subGrid.Children.Add(image);
                        subGrid.Children.Add(actionGrid);

                        actionGrid.Children.Add(tb);
                        actionGrid.Children.Add(messBorder);
                        actionGrid.Children.Add(actBorder);

                        FriendsPlace.Children.Add(grid);
                    }
                }

                
            }
               
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            FriendsPlace.Children.Clear();
            var users = NetWork.CountUsers().Split('|');
                foreach (var user in users)
                {
                    if (user != "")
                    {
                        if (int.Parse(user) != Classes.Hndr.id)
                    {
                        if (NetWork.GetLogin(int.Parse(user)).Contains((sender as TextBox).Text))
                        {
                            //Начальный грид
                            Grid grid = new Grid();
                            grid.Background = new SolidColorBrush(Colors.Transparent);
                            grid.Width = 250;
                            grid.Height = 150;
                            grid.Margin = new Thickness(20);
                            grid.Cursor = Cursors.Hand;
                            //Линии для грида
                            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100) });
                            grid.RowDefinitions.Add(new RowDefinition());
                            //Размеры грида
                            //Сабгрид aka Первый грид ров
                            Grid subGrid = new Grid();
                            //Имя профиля aka Второй грид ров

                            TextBlock NickName = new TextBlock();
                            NickName.VerticalAlignment = VerticalAlignment.Center;
                            NickName.FontSize = 16;
                            NickName.FontFamily = new FontFamily("Cascadia Mono");
                            NickName.TextWrapping = TextWrapping.Wrap;
                            NickName.Style = (Style)FindResource("MenuCategory");
                            NickName.Text = NetWork.GetLogin(int.Parse(user));
                            NickName.Name = "ID" + user;
                            NickName.MouseDown += ShowProfile;
                            //колонки для грида
                            subGrid.ColumnDefinitions.Add(new ColumnDefinition());
                            subGrid.ColumnDefinitions.Add(new ColumnDefinition());
                            //Фото профиля aka Первый грид колумн

                            var binaryData = Convert.FromBase64String(Hndr.photo);
                            BitmapImage bi = new BitmapImage();
                            bi.BeginInit();
                            bi.StreamSource = new MemoryStream(binaryData);
                            bi.EndInit();
                            Image image = new Image();
                            image.Source = bi;
                            image.Width = 80;
                            image.Stretch = Stretch.Fill;
                            image.Height = 80;
                            image.HorizontalAlignment = HorizontalAlignment.Left;
                            EllipseGeometry eg = new EllipseGeometry();
                            eg.Center = new Point(40, 40);
                            eg.RadiusX = 40;
                            eg.RadiusY = 40;
                            image.Clip = eg;
                            //Второй грид колумн
                            Grid actionGrid = new Grid();

                            Grid.SetColumn(image, 0);
                            Grid.SetColumn(actionGrid, 1);
                            //Колонки для него
                            actionGrid.RowDefinitions.Add(new RowDefinition());
                            actionGrid.RowDefinitions.Add(new RowDefinition());
                            actionGrid.RowDefinitions.Add(new RowDefinition());

                            TextBlock tb = new TextBlock();
                            tb.Text = NetWork.GetStatus(int.Parse(user)) == 1 ? "Онлайн" : "Офлайн";
                            tb.VerticalAlignment = VerticalAlignment.Center;
                            tb.FontSize = 14;
                            tb.Foreground = NetWork.GetStatus(int.Parse(user)) == 1 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Gray);

                            Border messBorder = new Border();
                            messBorder.Style = (Style)FindResource("ButtonStyle");

                            TextBlock messText = new TextBlock();
                            messText.Text = "Сообщение";
                            messText.Style = (Style)FindResource("ButtonText");
                            messBorder.Child = messText;

                            Border actBorder = new Border();
                            actBorder.Style = (Style)FindResource("ButtonStyle");
                            actBorder.Name = "ID" + user;



                            TextBlock actText = new TextBlock();
                            if (NetWork.isExistingFriendship(Classes.Hndr.id, int.Parse(user)))
                            {
                                actBorder.MouseDown += RemoveFriend;
                                actText.Text = "Удалить";
                            }
                            else if (NetWork.isExistingRequest(Classes.Hndr.id, int.Parse(user)))
                            {
                                actText.Text = "Отправлено";
                            }

                            else
                            {
                                actBorder.MouseDown += SendRequest;
                                actText.Text = "Добавить";
                            }
                            actText.Style = (Style)FindResource("ButtonText");
                            actBorder.Child = actText;

                            Grid.SetRow(tb, 0);
                            Grid.SetRow(messBorder, 1);
                            Grid.SetRow(actBorder, 2);

                            Grid.SetRow(subGrid, 0);
                            grid.Children.Add(subGrid);
                            Grid.SetRow(NickName, 1);
                            grid.Children.Add(NickName);
                            Grid.SetColumn(image, 0);
                            subGrid.Children.Add(image);
                            subGrid.Children.Add(actionGrid);

                            actionGrid.Children.Add(tb);
                            actionGrid.Children.Add(messBorder);
                            actionGrid.Children.Add(actBorder);

                            FriendsPlace.Children.Add(grid);
                        }
                    }
                }
            }
        }
    }

}
