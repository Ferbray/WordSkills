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
using System.Threading;

namespace ZMQP.Windows
{
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

        private void ToolBarGrid_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void ImageHamburgerButton_MouseDown(object sender, MouseButtonEventArgs e)
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

                ImageHamburgerButton.Visibility = Visibility.Hidden;
                LineHamburgerButton.Visibility = Visibility.Hidden;
                Line2HamburgerButton.Visibility = Visibility.Hidden;
                GridHamburger.Margin = new Thickness(15, 30, 0, 0);
                GridHamburger.HorizontalAlignment = HorizontalAlignment.Left;

                foreach(var i in GridHamburger.RowDefinitions)
                {
                    i.Height = new GridLength(30);
                }

                HomeHamburgerButton.Height = 20;
                HomeHamburgerButton.Width = 20;
                HomeHamburgerButton.Margin = new Thickness(0);
                ProfileHamburgerButton.Height = 20;
                ProfileHamburgerButton.Width = 20;
                ProfileHamburgerButton.Margin = new Thickness(0);
                LibraryHamburgerButton.Height = 20;
                LibraryHamburgerButton.Width = 20;
                LibraryHamburgerButton.Margin = new Thickness(0);
                SettingsHamburgerButton.Height = 20;
                SettingsHamburgerButton.Width = 20;
                SettingsHamburgerButton.Margin = new Thickness(0);
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

                ImageHamburgerButton.Visibility = Visibility.Visible;
                LineHamburgerButton.Visibility = Visibility.Visible;
                Line2HamburgerButton.Visibility = Visibility.Visible;
                GridHamburger.Margin = new Thickness(0);
                GridHamburger.HorizontalAlignment = HorizontalAlignment.Center;

                foreach (var i in GridHamburger.RowDefinitions)
                {
                    i.Height = new GridLength(0.18, GridUnitType.Star);
                }

                HomeHamburgerButton.Height = 25;
                HomeHamburgerButton.Width = 25;
                HomeHamburgerButton.Margin = new Thickness(0);
                ProfileHamburgerButton.Height = 25;
                ProfileHamburgerButton.Width = 25;
                ProfileHamburgerButton.Margin = new Thickness(0);
                LibraryHamburgerButton.Height = 25;
                LibraryHamburgerButton.Width = 25;
                LibraryHamburgerButton.Margin = new Thickness(0);
                SettingsHamburgerButton.Height = 25;
                SettingsHamburgerButton.Width = 25;
                SettingsHamburgerButton.Margin = new Thickness(0);
            }
        }

        private void HamburgerToolHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.MainPage();
            HambMenuV2.Visibility = Visibility.Hidden;
        }

        private void HamburgerToolProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.Profile();
            HambMenuV2.Visibility = Visibility.Hidden;
        }

        private void HamburgerToolSettings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.Settings();
            HambMenuV2.Visibility = Visibility.Hidden;
        }


        private void SearchHeadBar_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void HamburgerToolLibrary_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.Library();
            HambMenuV2.Visibility = Visibility.Hidden;
        }

        private void HamburgerToolFriends_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.Friends();
            HambMenuV2.Visibility = Visibility.Hidden;
        }

        private void HamburgerMenuVisible(object sender, MouseEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();

            doubleAnimation.From = 0;
            doubleAnimation.To = 150;
            doubleAnimation.Duration = TimeSpan.FromSeconds(0.1);
            BorderMenuV2.BeginAnimation(Grid.HeightProperty, doubleAnimation);
            HambMenuV2.Visibility = Visibility.Visible;
            
        }

        private void HamburgerMenuHidden(object sender, MouseEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();

            doubleAnimation.From = 150;
            doubleAnimation.To = 0;
            doubleAnimation.Duration = TimeSpan.FromSeconds(0.1);
            BorderMenuV2.BeginAnimation(Grid.HeightProperty, doubleAnimation);

            HambMenuV2.Visibility = Visibility.Hidden;
        }


        private void SetLogin(object sender, EventArgs e)
        {
            ProfileName.Text = Classes.Hndr.login;
        }

    }
}
