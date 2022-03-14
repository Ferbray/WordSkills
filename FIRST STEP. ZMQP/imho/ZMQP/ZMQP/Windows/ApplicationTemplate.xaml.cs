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
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (HamburgerMenu.Width == 50)
            {
                HamburgerMenu.Width = 300;
                HamburgerMenuVisibility.Visibility = Visibility.Visible;
                HamburgerMenuHidden.Visibility = Visibility.Hidden;
            }
            else
            {
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
    }
}
