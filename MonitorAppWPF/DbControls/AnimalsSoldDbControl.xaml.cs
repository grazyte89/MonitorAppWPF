using PetsEntityLib.DataBaseExtractions;
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

namespace MonitorAppWPF.DbControls
{
    /// <summary>
    /// Interaction logic for AnimalsSoldDbControl.xaml
    /// </summary>
    public partial class AnimalsSoldDbControl : UserControl
    {
        public AnimalsSoldDbControl()
        {
            InitializeComponent();
        }

        private void BtnCustomersAndAnimals_Click(object sender, RoutedEventArgs e)
        {
            _dgAnimals.DataContext = RetrieveAnimals.GetAllAnimals();
            _dgCustomer.DataContext = RetrieveCustomers.GetCustomersTop(100);
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSellAnimal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GdAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GdCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
