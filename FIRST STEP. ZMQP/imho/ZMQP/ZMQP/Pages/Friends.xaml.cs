using System;
using System.Collections.Generic;
using System.IO;
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
using ZMQP.Windows;

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

        private void RemoveFriend(object sender, RoutedEventArgs e)
        {
            NetWork.RemoveFriend(Hndr.id, int.Parse((sender as Border).Name.Remove(0, 2)));
            this.NavigationService.Navigate(new Pages.Friends());
        }

        private void ShowProfile(object sender, RoutedEventArgs e)
        {
            Classes.Hndr.friendid = int.Parse((sender as TextBlock).Name.Remove(0, 2));

            this.NavigationService.Navigate(new Pages.UserProfileTemplate());
        }

        private void LoadedFriends(object sender, RoutedEventArgs e)
        {
            var friends = NetWork.GetFriend(Hndr.id).Split('|');
                foreach (var friend in friends)
                {

                    if (friend != "")
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
                    NickName.Text = friend;
                    NickName.Name = "ID" + friend;
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
                    image.Height = 80;
                    image.Stretch = Stretch.Fill;
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
                    tb.Text = NetWork.GetStatus(int.Parse(friend)) == 1 ? "Онлайн": "Офлайн";
                    tb.VerticalAlignment = VerticalAlignment.Center;
                    tb.FontSize = 14;
                    tb.Foreground = NetWork.GetStatus(int.Parse(friend)) == 1 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Gray);

                    Border messBorder = new Border();
                    messBorder.Style = (Style)FindResource("ButtonStyle");

                    TextBlock messText = new TextBlock();
                    messText.Text = "Сообщение";
                    messText.Style = (Style)FindResource("ButtonText");
                    messBorder.Child = messText;


                    Border actBorder = new Border();
                    actBorder.Style = (Style)FindResource("ButtonStyle");
                    actBorder.MouseDown += RemoveFriend;
                    actBorder.Name = "ID" + friend;

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

        private void ShowRequests(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.RequestFriends());
        }
    }
}
