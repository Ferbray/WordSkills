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
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace ZMQP.Windows
{
    /// <summary>
    /// Логика взаимодействия для ApplicationTemplate.xaml
    /// </summary>
    public partial class ApplicationTemplate : Window
    {
        public ApplicationTemplate()
        {
            InitializeComponent();
            MainFrame.Content = new Pages.MainPage();
        }

        private void ToolBarButtonMin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToolBarButtonClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }


        private void ToolBarButtonRes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.Profile();
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.MainPage();
            HambMenuV2.Visibility = Visibility.Hidden;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();

            if (HamburgerMenu.Width == 50)
            {
                doubleAnimation.From = 50;
                doubleAnimation.To = 300;
                doubleAnimation.Duration = TimeSpan.FromSeconds(0.245);
                HamburgerMenu.BeginAnimation(Grid.WidthProperty, doubleAnimation);
                HamburgerMenu.Width = 300;
                HamburgerMenuVisibility.Visibility = Visibility.Visible;
                HamburgerMenuHidden.Visibility = Visibility.Hidden;
            }
            else
            {
                doubleAnimation.From = 300;
                doubleAnimation.To = 50;
                doubleAnimation.Duration = TimeSpan.FromSeconds(0.245);
                HamburgerMenu.BeginAnimation(Grid.WidthProperty, doubleAnimation);
                HamburgerMenu.Width = 50;
                HamburgerMenu.HorizontalAlignment = HorizontalAlignment.Right;
                HamburgerMenuVisibility.Visibility = Visibility.Hidden;
                HamburgerMenuHidden.Visibility = Visibility.Visible;
            }
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.MainPage();
        }

        private void Image_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.Profile();
        }

        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();

            if (HambMenuV2.Visibility == Visibility.Hidden)
            {
                doubleAnimation.From = 0;
                doubleAnimation.To = 150;
                doubleAnimation.Duration = TimeSpan.FromSeconds(0.1);
                HambMenuV2.BeginAnimation(Grid.HeightProperty, doubleAnimation);
                HambMenuV2.Visibility = Visibility.Visible;
            }
            else
            {
                HambMenuV2.Visibility = Visibility.Hidden;
            }
        }

        private void TextBlock_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.Profile();
            HambMenuV2.Visibility = Visibility.Hidden;
        }

        private void TextBlock_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.Settings();
            HambMenuV2.Visibility = Visibility.Hidden;
        }

        private void TextBlock_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.Settings();
            HambMenuV2.Visibility = Visibility.Hidden;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchText.Text = "";
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0 )
            {
                SearchText.Text = "Search...";
            }
        }

        private void TextBlock_MouseDown_5(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.Library();
            HambMenuV2.Visibility = Visibility.Hidden;
        }

        private void TextBlock_MouseDown_6(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.Library();
            HambMenuV2.Visibility = Visibility.Hidden;
        }

        private void TextBlock_MouseDown_7(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.Friends();
            HambMenuV2.Visibility = Visibility.Hidden;
        }

        private void TextBlock_MouseDown_8(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.Friends();
            HambMenuV2.Visibility = Visibility.Hidden;
        }
    }
}
