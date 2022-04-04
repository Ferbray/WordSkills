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

namespace ZMQP.Pages
{
    /// <summary>
    /// Логика взаимодействия для RequestFriends.xaml
    /// </summary>
    public partial class RequestFriends : Page
    {
        public RequestFriends()
        {
            InitializeComponent();
        }

        private void ShowResponse(object sender, MouseButtonEventArgs e)
        {
            RequestPlace.Visibility = Visibility.Hidden;
            ResponseRequestsText.Text = "Входящие";
            ResponsePlace.Visibility = Visibility.Visible;
        }

        private void ShowRequests(object sender, MouseButtonEventArgs e)
        {
            ResponsePlace.Visibility = Visibility.Hidden;
            ResponseRequestsText.Text = "Исходящие";
            RequestPlace.Visibility = Visibility.Visible;
        }

        private void AcceptFriend(object sender, RoutedEventArgs e)
        {
            NetWork.AcceptFriend(Hndr.id, int.Parse((sender as Border).Name.Remove(0, 2)));
            this.NavigationService.Navigate(new Pages.RequestFriends());

        }

        private void DeleteRequest(object sender, MouseButtonEventArgs e)
        {
            NetWork.DeleteRequest(Hndr.id, int.Parse((sender as Border).Name.Remove(0, 2)));
            this.NavigationService.Navigate(new Pages.RequestFriends());
        }

        private void DeclineFriend(object sender, RoutedEventArgs e)
        {
            NetWork.DeleteFriend(Hndr.id, int.Parse((sender as Border).Name.Remove(0, 2)));
            this.NavigationService.Navigate(new Pages.RequestFriends());
        }

        private void ShowProfile(object sender, RoutedEventArgs e)
        {
            Classes.Hndr.friendid = int.Parse((sender as TextBlock).Name.Remove(0, 2));

            this.NavigationService.Navigate(new Pages.UserProfileTemplate());
        }

        private void LoadResponse(object sender, RoutedEventArgs e)
        {
            ResponseRequestsText.Text = "Входящие";
            var friends = NetWork.GetResponse(Hndr.id).Split('|');
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
                    NickName.Text = NetWork.GetLogin(int.Parse(friend));
                    NickName.Name = "ID" + friend.ToString();
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
                    tb.Text = NetWork.GetStatus(int.Parse(friend)) == 1 ? "Онлайн" : "Офлайн";
                    tb.VerticalAlignment = VerticalAlignment.Center;
                    tb.FontSize = 14;
                    tb.Foreground = NetWork.GetStatus(int.Parse(friend)) == 1 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Gray);


                    Border messBorder = new Border();
                    messBorder.Style = (Style)FindResource("ButtonStyle");

                    TextBlock messText = new TextBlock();
                    messText.Text = "Принять";
                    messText.Style = (Style)FindResource("ButtonText");

                    messBorder.Name = "ID" + friend;
                    messBorder.Child = messText;
                    messBorder.MouseDown += AcceptFriend;

                    Border actBorder = new Border();
                    actBorder.Style = (Style)FindResource("ButtonStyle");
                    actBorder.Name = "ID" + friend;
                    actBorder.MouseDown += DeleteRequest;



                    TextBlock actText = new TextBlock();
                    actText.Text = "Отклонить";
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

                    ResponsePlace.Children.Add(grid);
                }
            }
                
        }

        private void LoadRequests(object sender, RoutedEventArgs e)
        {
            var friends = NetWork.GetRequests(Hndr.id).Split('|');
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
                    NickName.Text = NetWork.GetLogin(int.Parse(friend));
                    NickName.Name = "ID" + friend.ToString();
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
                    tb.Text = NetWork.GetStatus(int.Parse(friend)) == 1 ? "Онлайн" : "Офлайн";
                    tb.VerticalAlignment = VerticalAlignment.Center;
                    tb.FontSize = 14;
                    tb.Foreground = NetWork.GetStatus(int.Parse(friend)) == 1 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Gray);

                    Border actBorder = new Border();
                    actBorder.Style = (Style)FindResource("ButtonStyle");
                    actBorder.Name = "ID" + friend;



                    TextBlock actText = new TextBlock();
                    actText.Text = "Отклонить";
                    actText.Style = (Style)FindResource("ButtonText");
                    actBorder.Child = actText;
                    actBorder.MouseDown += DeclineFriend;

                    Grid.SetRow(tb, 0);
                    Grid.SetRow(actBorder, 2);

                    Grid.SetRow(subGrid, 0);
                    grid.Children.Add(subGrid);
                    Grid.SetRow(NickName, 1);
                    grid.Children.Add(NickName);
                    Grid.SetColumn(image, 0);
                    subGrid.Children.Add(image);
                    subGrid.Children.Add(actionGrid);

                    actionGrid.Children.Add(tb);
                    actionGrid.Children.Add(actBorder);

                    RequestPlace.Children.Add(grid);
                }
            }
        }
        }

        
    }
