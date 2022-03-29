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

        private string GetName(int Id)
        {
            using (UserContext db = new UserContext())
            {
                var users = db.Users;

                foreach (var user in users)
                {
                    if (user.Id == Id)
                        return user.Login;
                }
                return null;
            }
        }

        private void LoadedFriends(object sender, RoutedEventArgs e)
        {
            using (FriendsContext db = new FriendsContext())
            {
                var users = db.UserFriends;

                foreach (var user in users)
                {
                    if (user.UserID == Classes.UserHandler.ID)
                    {
                        //Начальный грид
                        Grid grid = new Grid
                        {

                            Background = new SolidColorBrush(Colors.Transparent),
                            Width = 250,
                            Height = 150,
                            Margin = new Thickness(20),
                            Cursor = Cursors.Hand
                        };
                        //Линии для грида
                        grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100) });
                        grid.RowDefinitions.Add(new RowDefinition());
                        //Размеры грида
                        //Сабгрид aka Первый грид ров
                        Grid subGrid = new Grid();
                        //Имя профиля aka Второй грид ров

                        TextBlock NickName = new TextBlock
                        {
                            VerticalAlignment = VerticalAlignment.Center,
                            FontSize = 16,
                            FontFamily = new FontFamily("Cascadia Mono"),
                            TextWrapping = TextWrapping.Wrap,
                            Style = (Style)FindResource("MenuCategory"),
                            Text = GetName(user.UserID)
                        };

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

                        EllipseGeometry eg = new EllipseGeometry
                        {
                            Center = new Point(40, 40),
                            RadiusX = 40,
                            RadiusY = 40
                        };

                        image.Clip = eg;
                        //Второй грид колумн
                        Grid actionGrid = new Grid();

                        Grid.SetColumn(image, 0);
                        Grid.SetColumn(actionGrid, 1);
                        //Колонки для него
                        actionGrid.RowDefinitions.Add(new RowDefinition());
                        actionGrid.RowDefinitions.Add(new RowDefinition());
                        actionGrid.RowDefinitions.Add(new RowDefinition());

                        TextBlock tb = new TextBlock
                        {
                            Text = "В сети",
                            VerticalAlignment = VerticalAlignment.Center,
                            FontSize = 14,
                            Foreground = new SolidColorBrush(Colors.Green)
                        };

                        Border messBorder = new Border
                        {
                            Style = (Style)FindResource("ButtonStyle")
                        };

                        TextBlock messText = new TextBlock
                        {
                            Text = "Сообщение",
                            Style = (Style)FindResource("ButtonText")
                        };
                        messBorder.Child = messText;


                        Border actBorder = new Border
                        {
                            Style = (Style)FindResource("ButtonStyle")
                        };

                        TextBlock actText = new TextBlock
                        {
                            Text = "Действия",
                            Style = (Style)FindResource("ButtonText")
                        };
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
