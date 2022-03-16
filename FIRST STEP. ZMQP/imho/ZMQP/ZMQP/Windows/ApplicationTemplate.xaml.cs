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
            Manager.MainFrame = MainFrame;
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

        private void TextBox_Initialized(object sender, EventArgs e)
        {
            (sender as TextBox).Text = "Search...";
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
        }

        private void TextBlock_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.Settings();
        }

        private void SearchHeadBar_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBlock_MouseDown_5(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Pages.MainPage();
        }
    }
}
