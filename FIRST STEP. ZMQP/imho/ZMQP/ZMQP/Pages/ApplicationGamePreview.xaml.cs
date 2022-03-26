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
    /// Логика взаимодействия для ApplicationGamePreview.xaml
    /// </summary>
    public partial class ApplicationGamePreview : Page
    {
        public ApplicationGamePreview()
        {
            InitializeComponent();
        
        }

        private List<string> infoGame(string title)
        {
            List<string> info = new List<string>();
            GamesContext db = new GamesContext();
            var games = db.Games.ToList();
            foreach (var game in games)
            {
                if (game.TitleGame == title)
                {
                    info.Add(game.Photo);
                    info.Add(game.Description);
                }
            }
            return info;
        }
        private void GameTitleLoaded(object sender, RoutedEventArgs e)
        {
            (sender as TextBlock).Text = Classes.Hndr.title;

        }

        private void DescriptionLoaded(object sender, RoutedEventArgs e)
        {
            (sender as TextBlock).Text = infoGame(Classes.Hndr.title)[1];
        }

        private void PicturePreviewLoaded(object sender, RoutedEventArgs e)
        {
            (sender as Image).Source = new BitmapImage(new Uri(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9) + infoGame(Classes.Hndr.title)[0], UriKind.Absolute));
        }
    }
}
