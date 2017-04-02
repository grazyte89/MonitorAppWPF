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
    /// Interaction logic for PetDbControl.xaml
    /// </summary>
    public partial class PetDbControl : UserControl
    {
        private volatile bool _tbCustomer2Collapsed;

        public PetDbControl()
        {
            InitializeComponent();
            _tbCustomer2Collapsed = false;
        }

        private void TbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_tbCustomer2Collapsed)
            {
                _tbCustomer2Collapsed = true;
                _tbCustomers2.Visibility = Visibility.Collapsed;
                _smallGrid.RowDefinitions.Remove(_row2);
            }
            else
            {
                _tbCustomer2Collapsed = false;
                _tbCustomers2.Visibility = Visibility.Visible;
                _smallGrid.RowDefinitions.Add(_row2);
            }
        }

        private void TbCustomers2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //_tbCustomers.Items.Clear();
            _tbCustomers.DataContext = PetsEntityLib.TestClass.GetCustomers();
            _tbCustomers2.DataContext = PetsEntityLib.TestClass.GetCustomers();
            PetsEntityLib.TestClass.CreateCustomer("TestTest3", "LastNameTest33");
        }
    }
}
