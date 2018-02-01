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

        public DBSubMenuControl()
        {
            InitializeComponent();
        }

        public DBSubMenuControl(ContentControl mainContent) : this()
        {
            _mainUserControl = mainContent;
        }

        private void ClearContent()
        {
            if (_mainUserControl != null && _mainUserControl.Content != null)
                _mainUserControl.Content = null;
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            //TestClass.ManyToManyCourse();
            //TestingUpdateCustomer.TestManyToMay();
            //TestingUpdateCustomer.TestAccountClass();
            TestingUpdateCustomer.TestTransactionClass();
        }
    }
}
