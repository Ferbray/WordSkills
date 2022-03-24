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

        private void AppendFriend(object sender, RoutedEventArgs e)
        {
           /* Classes.DataBase database = new Classes.DataBase();
            database.openConnection();
            string id = (sender as Border).Name;
            database.AddFriend(id.Remove(0,2));*/
        }
        private void LoadedFriends(object sender, RoutedEventArgs e)
        {/*
            Classes.DataBase database = new Classes.DataBase();
            database.openConnection();
            string[] users = database.Users();
            foreach (string user in users)
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
                NickName.Text = user;
                NickName.Name = "NickName";
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
                actBorder.Name = "ID" + database.getID(user).ToString();
                actBorder.MouseDown += AppendFriend;

                TextBlock actText = new TextBlock();
                actText.Text = "Добавить";
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
            database.closeConnection();*/
        }

    }

}
