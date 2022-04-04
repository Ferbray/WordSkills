using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ZMQP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (StreamReader writer = new StreamReader(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9) + "userdata/config.ini", false))
            {
                if (Classes.NetWork.CheckConnection())
                {
                    if (writer.ReadToEnd() == "")
                    {
                        Windows.Login lg = new Windows.Login();
                        this.Close();
                        lg.Show();
                    }
                    else
                    {
                        Classes.Getter.RememberFunc();
                        Windows.ApplicationTemplate at = new Windows.ApplicationTemplate();
                        this.Close();
                        at.Show();
                    }
                }
                else
                {
                    Windows.Registration lg = new Windows.Registration();
                    this.Close();
                    lg.Show();
                }
                
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
