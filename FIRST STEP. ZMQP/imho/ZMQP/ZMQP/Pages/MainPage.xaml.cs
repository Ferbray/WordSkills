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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void ShowGameDescription(object sender, MouseButtonEventArgs e)
        {
           /* string title = (sender as TextBlock).Text;
            Classes.DataBase.GameTitle = title;
            this.NavigationService.Navigate(new Pages.ApplicationGamePreview());*/
        }

        private void LoadGame(object sender, EventArgs e)
        {
         /*   Classes.DataBase database = new Classes.DataBase();
            database.openConnection();
            string[] games = database.Games();
            foreach (string game in games)
            {
                string[] gameInfo = game.Split('|');
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
                ImageSource bitmapImage = new BitmapImage(new Uri(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length-9) + gameInfo[2], UriKind.Absolute));
                image.Stretch = Stretch.Fill;
                image.Source = bitmapImage;


                TextBlock textBlock = new TextBlock();
                textBlock.FontSize = 16;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Text = gameInfo[1];
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
            database.closeConnection();*/

        }

    }
}
