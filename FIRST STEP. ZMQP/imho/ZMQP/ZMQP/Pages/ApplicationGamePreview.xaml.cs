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
    /// Логика взаимодействия для ApplicationGamePreview.xaml
    /// </summary>
    public partial class ApplicationGamePreview : Page
    {
        public ApplicationGamePreview()
        {
            InitializeComponent();
        
        }

        private string[] infoGame(string title)
        {
            string[] info = new string[2];
            Classes.DataBase database = new Classes.DataBase();
            database.openConnection();
            string[] games = database.Games();
            foreach (string game in games)
            {
                string[] gameInfo = game.Split('|');
                if (gameInfo[1] == title)
                {
                    info[0] = gameInfo[2];
                    info[1] = gameInfo[3];
                }
            }
            return info;
        }
        private void GameTitleLoaded(object sender, RoutedEventArgs e)
        {
            (sender as TextBlock).Text = Classes.DataBase.GameTitle;
            
        }

        private void DescriptionLoaded(object sender, RoutedEventArgs e)
        {
            (sender as TextBlock).Text = infoGame(Classes.DataBase.GameTitle)[1];
        }

        private void PicturePreviewLoaded(object sender, RoutedEventArgs e)
        {
            (sender as Image).Source = new BitmapImage(new Uri(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9) + infoGame(Classes.DataBase.GameTitle)[0], UriKind.Absolute));
        }
    }
}
