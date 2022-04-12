using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace WpfFirst
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly HttpClient HttpClient = new HttpClient();

        public App()
        {
            Exit += App_Exit;

        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            HttpClient.Dispose();        
        }
    }
}
