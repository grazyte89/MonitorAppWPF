using System.Windows;
using System.Windows.Controls;
using TestCollectionLib;
using TestCollectionLib.M2MTests;

namespace MonitorAppWPF.MenuControls
{
    /// <summary>
    /// Interaction logic for DBSubMenuControl.xaml
    /// </summary>
    public partial class DBSubMenuControl : UserControl
    {
        private ContentControl _mainUserControl;

        public DBSubMenuControl(ContentControl mainContent)
        {
            InitializeComponent();
            _mainUserControl = mainContent;
        }

        private void BtnAnimal_Click(object sender, RoutedEventArgs e)
        {
            this.ClearContent();
            this._mainUserControl.Content = new DbControls.AnimalsDbControl();
        }

        private void BtnCustomers_Click(object sender, RoutedEventArgs e)
        {
            this.ClearContent();
            this._mainUserControl.Content = new DbControls.CustomerDBControl();
        }

        private void ClearContent()
        {
            if (_mainUserControl.Content != null)
                _mainUserControl.Content = null;
        }

        private void BtnStocks_Click(object sender, RoutedEventArgs e)
        {
            this.ClearContent();
            this._mainUserControl.Content = new DbControls.StockDbControl();
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            //TestClass.ManyToManyCourse();
            //TestingUpdateCustomer.TestManyToMay();
            TestingUpdateCustomer.TestAccountClass();
        }

        private void BtnAnimalSold_Click(object sender, RoutedEventArgs e)
        {
            this.ClearContent();
            this._mainUserControl.Content = new DbControls.AnimalsSoldDbControl();
        }
    }
}
