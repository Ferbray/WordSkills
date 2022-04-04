using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ZMQP.Windows
{
    /// <summary>
    /// Логика взаимодействия для DownloadVieewr.xaml
    /// </summary>
    public partial class DownloadViewer : Window
{
    public DownloadViewer()
    {
        InitializeComponent();
    }
        private void DragNDrop(object sender, MouseButtonEventArgs e)
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

        private void TextBox_Initialized(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9);
            DownloadPath.Text = path + $@"Games\{Regex.Replace(Classes.Hndr.title, @"[^\w\d]", " ")}";
        }

        private void ShowOpenDialog(object sender, MouseButtonEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)

                    DownloadPath.Text = dialog.SelectedPath;
            }
        }

        private void DiscardChanges(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void AcceptChanges(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Directory.CreateDirectory(DownloadPath.Text);
                Classes.Getter.DownloadGame(Classes.Hndr.title, DownloadPath.Text, "sample.exe");
                this.Close();
            }
            catch
            {
                DownloadErrorText.Visibility = Visibility.Visible;
            }
        }
    }
}
