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
    /// Логика взаимодействия для Friends.xaml
    /// </summary>
    public partial class Friends : Page
    {
        public Friends()
        {
            InitializeComponent();
        }

        private string GetNameFriend(int id)
        {
            UserContext uc = new UserContext();
            var users = uc.Users.ToList();
            foreach (var user in users)
            {
                if (user.ID == id)
                {
                    return user.Login;
                }
            }

            return "Unknown";
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

        private void RemoveFriend(object sender, RoutedEventArgs e)
        {
            using (FriendshipContext db = new FriendshipContext())
            {
                var friends = db.Friendships;
                foreach (var friend in friends)
                {
                    if (Classes.Hndr.id == friend.IDUser && GetFriendId((sender as Border).Name) == friend.IDFriend)
                    {
                        db.Friendships.Remove(friend);
                    }
                }
                db.SaveChanges();
                this.NavigationService.Navigate(new Pages.Friends());
            }
        }

        private void LoadedFriends(object sender, RoutedEventArgs e)
        {
            FriendshipContext db = new FriendshipContext();
            var friends = db.Friendships.ToList();
            foreach (var friend in friends)
            {
                if (friend.IDUser == Classes.Hndr.id)
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
                    NickName.Text = GetNameFriend(friend.IDFriend);
                    //колонки для грида
                    subGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    subGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    //Фото профиля aka Первый грид колумн
                    Image image = new Image();
                    Uri uri = new Uri("/Resources/photo_2022-01-07_17-08-19 (2).jpg", UriKind.Relative);
                    image.Source = new BitmapImage(uri);
                    image.Width = 80;
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
                    tb.Text = "В сети";
                    tb.VerticalAlignment = VerticalAlignment.Center;
                    tb.FontSize = 14;
                    tb.Foreground = new SolidColorBrush(Colors.Green);

                    Border messBorder = new Border();
                    messBorder.Style = (Style)FindResource("ButtonStyle");

                    TextBlock messText = new TextBlock();
                    messText.Text = "Сообщение";
                    messText.Style = (Style)FindResource("ButtonText");
                    messBorder.Child = messText;
                    

                    Border actBorder = new Border();
                    actBorder.Style = (Style)FindResource("ButtonStyle");
                    actBorder.MouseDown += RemoveFriend;
                    actBorder.Name = "ID" + friend.IDFriend;

                    TextBlock actText = new TextBlock();
                    actText.Text = "Удалить";
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

        private void FindFriends(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.FindFriends());
        }
    }
}
