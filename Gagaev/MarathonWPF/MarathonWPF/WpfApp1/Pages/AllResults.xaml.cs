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
using System.Collections.ObjectModel;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllResults.xaml
    /// </summary>
    public partial class AllResults : Page
    {
        private ObservableCollection<Results> _results = new ObservableCollection<Results>();
        public AllResults()
        {
            InitializeComponent();
            combo_marathon.Items.Add("2014 Japan");
            combo_marathon.Items.Add("2013 Germany");
            combo_marathon.Items.Add("2012 Vietnam");
            combo_marathon.Items.Add("2011 United Kingdom");

            combo_distance.Items.Add("41 km Marathon");
            combo_distance.Items.Add("21 km Marathon");
            combo_distance.Items.Add("7 km Marathon");

            combo_gender.Items.Add("M");
            combo_gender.Items.Add("Ж");
            combo_gender.Items.Add("Все");

            combo_category.Items.Add("18-29");
            combo_category.Items.Add("14-18");
            combo_category.Items.Add("29-40");

            BegunsGrid.IsReadOnly = true;
            BegunsGrid.CanUserResizeColumns = true;
            BegunsGrid.CanUserResizeRows = true;
            BegunsGrid.ItemsSource = _results;
        }

        private void Cancel_Pay(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _results.Add((new Results()
            {
                Place = 1, 
                Time = DateTime.Now, 
                Name = "Ivan", 
                Country = "RUS"
            }));
        }
    }
}
