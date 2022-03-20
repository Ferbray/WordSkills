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
            this.NavigationService.Navigate(new Pages.ApplicationGamePreview());
        }

        private void LoadGame(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Grid grid = new Grid();
                grid.Background = new SolidColorBrush(Colors.Transparent);
                grid.Width = 200;
                grid.Height = 150;
                grid.Cursor = Cursors.Hand;
                grid.MouseDown += ShowGameDescription;
                RowDefinition row1 = new RowDefinition();
                RowDefinition row2 = new RowDefinition();
                row1.Height = new GridLength(100, GridUnitType.Star);
                row2.Height = new GridLength(50, GridUnitType.Star);
                grid.Margin = new Thickness(20);

                Image image = new Image();
                Uri uri = new Uri("/Resources/DefaultGameBg.png", UriKind.Relative);
                image.Stretch = Stretch.Fill;
                image.Source = new BitmapImage(uri);


                TextBlock textBlock = new TextBlock();
                textBlock.FontSize = 16;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Text = "Dota 2";
                textBlock.FontFamily = new FontFamily("Cascadia Mono");
                textBlock.Style = (Style)FindResource("MenuCategory");

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
