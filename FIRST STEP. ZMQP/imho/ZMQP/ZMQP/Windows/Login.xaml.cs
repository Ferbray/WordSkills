﻿using System;
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

namespace ZMQP.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ToolBarButtonClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ToolBarButtonMin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Windows.Registration Registration = new Windows.Registration();
            Registration.Show();
            this.Close();
        }

        private void PassBoxButtonVisibility_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PassBoxVisibility.Visibility == Visibility.Visible)
            {
                String stringPath = "/Resources/eyeNo.png";
                Uri imageUri = new Uri(stringPath, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);

                PassBoxVisibility.Visibility = Visibility.Collapsed;
                PassBoxNoVisibility.Visibility = Visibility.Visible;
                PassBoxNoVisibility.Password = PassBoxVisibility.Text;

                PassBoxButtonVisibility.Source = imageBitmap;
            }

            else
            {
                String stringPath2 = "/Resources/eye.png";
                Uri imageUri2 = new Uri(stringPath2, UriKind.Relative);
                BitmapImage imageBitmap2 = new BitmapImage(imageUri2);

                PassBoxVisibility.Visibility = Visibility.Visible;
                PassBoxNoVisibility.Visibility = Visibility.Collapsed;
                PassBoxVisibility.Text = PassBoxNoVisibility.Password;

                PassBoxButtonVisibility.Source = imageBitmap2;
            }
        }

        private void Verification_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            Classes.DataBase database = new Classes.DataBase();

            database.openConnection();
            if (database.VerificationUser(LoginBox.Text, PassBoxNoVisibility.Password))
            {
                Windows.ApplicationTemplate at = new Windows.ApplicationTemplate();
                this.Close();
                at.Show();
            }
            else
            {
                ErrorText.Visibility = Visibility.Visible;
            }

            database.closeConnection();
        }



        /*
       private void TextBox_GotFocus(object sender, RoutedEventArgs e)
       {
           (sender as TextBox).BorderBrush = new SolidColorBrush(Color.FromRgb(177, 1, 1));
       }*/
    }
}
