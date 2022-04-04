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
    /// Логика взаимодействия для Library.xaml
    /// </summary>
    public partial class Library : Page
    {
        public Library()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ShowGameDescription(object sender, MouseButtonEventArgs e)
        {
            string title = (sender as TextBlock).Text;
            Classes.Hndr.title = title;
            this.NavigationService.Navigate(new Pages.ApplicationGamePreview());
        }
        private void MainPlace_Loaded(object sender, RoutedEventArgs e)
        {
            using (GamesContext db = new GamesContext())
            {
                var games = db.Games.ToList();
                foreach (var game in games)
                {
                    if (Getter.IsDownload(game.TitleGame))
                    {
                        Grid grid = new Grid();
                        grid.Background = new SolidColorBrush(Colors.Transparent);
                        grid.Width = 200;
                        grid.Height = 150;
                        grid.Cursor = Cursors.Hand;
                        RowDefinition row1 = new RowDefinition();
                        RowDefinition row2 = new RowDefinition();
                        row1.Height = new GridLength(100, GridUnitType.Star);
                        row2.Height = new GridLength(50, GridUnitType.Star);
                        grid.Margin = new Thickness(20);

                        Image image = new Image();
                        ImageSource bitmapImage = new BitmapImage(new Uri(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9) + game.Photo, UriKind.Absolute));
                        image.Stretch = Stretch.Fill;
                        image.Source = bitmapImage;


                        TextBlock textBlock = new TextBlock();
                        textBlock.FontSize = 16;
                        textBlock.VerticalAlignment = VerticalAlignment.Center;
                        textBlock.TextWrapping = TextWrapping.Wrap;
                        textBlock.Text = game.TitleGame;
                        textBlock.FontFamily = new FontFamily("Cascadia Mono");
                        textBlock.Style = (Style)FindResource("MenuCategory");
                        textBlock.MouseDown += ShowGameDescription;

                        grid.RowDefinitions.Add(row1);

                        grid.Children.Add(image);
                        grid.RowDefinitions.Add(row2);
                        grid.Children.Add(textBlock);
                        Grid.SetRow(image, 0);
                        Grid.SetRow(textBlock, 1);

                        MainPlace.Children.Add(grid);
                    }
                }
            }
            
        }
    }
}
