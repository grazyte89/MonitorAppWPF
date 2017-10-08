using MonitorAppWPF.UiConstants;
using PetsEntityLib.DataBaseExtractions;
using PetsEntityLib.DataBasePersistances;
using PetsEntityLib.DataBaseUpdates;
using PetsEntityLib.Entities;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MonitorAppWPF.DbControls
{
    /// <summary>
    /// Interaction logic for StockDbControl.xaml
    /// </summary>
    public partial class StockDbControl : UserControl
    {
        //private Stock _currentStock;
        //private string _newEditMode;

        public StockDbControl()
        {
            InitializeComponent();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            this.ExapndEditPanel();
            //_gdStocks.IsEnabled = false;
            //_newEditMode = Constants.Edit;
        }

        /*private void BtnStocks_Click(object sender, RoutedEventArgs e)
        {
            _gdStocks.DataContext = RetrieveStocks.GetAllStocks();
        }*/

        private void BtnCreateNewStocks_Click(object sender, RoutedEventArgs e)
        {
            this.ExapndEditPanel();
            /*_currentStock = new Stock();
            _pnEditSection.DataContext = _currentStock;
            _newEditMode = Constants.New;*/
        }

        private void ExapndEditPanel()
        {
            _pnEditSection.Visibility = Visibility.Visible;

            ThicknessAnimation epxandPanelAnimation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(2)),
                From = new Thickness(0f, _gdStocks.ActualHeight, 0f, 0f),
                To = new Thickness(0f, _gdStocks.ActualHeight / 2f, 0f, 0f),
                DecelerationRatio = 0.9f
            };

            Storyboard.SetTargetProperty(epxandPanelAnimation, new PropertyPath("Margin"));
            Storyboard sbEditSection = Resources["_sbExpandEdit"] as Storyboard;
            sbEditSection.Children.Add(epxandPanelAnimation);
            sbEditSection.Begin(_pnEditSection);
        }

        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            /*if (_currentStock == null)
                return;
            this.UpdateSource();
            if (_newEditMode.Equals(Constants.New))
                this.CreateNewStockItem(_currentStock);
            else if (_newEditMode.Equals(Constants.Edit) && _currentStock != null)
                this.UpdateStock(_currentStock);
            _gdStocks.IsEnabled = true;*/
            this.CollapseEditPanel();
        }

        /*private void CreateStocks(Stock stock)
        {
            CreateStocksClass createStock = new CreateStocksClass(null);
            createStock.AddItem(stock);
            createStock.SaveCreatedItems();
        }

        private void UpdateStock(Stock stock)
        {
            UpdateStockClass updateStock = new UpdateStockClass(stock);
            updateStock.SaveUpdate();
        }

        private void CreateNewStockItem(Stock stock)
        {
            CreateStocksClass createStock = new CreateStocksClass(null);
            createStock.AddItem(stock);
            createStock.SaveCreatedItems();
        }*/

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            //this.RestoreToOriginal();
            //_currentStock = null;
            //_gdStocks.IsEnabled = true;
            this.CollapseEditPanel();
        }

        private void CollapseEditPanel()
        {
            ThicknessAnimation collapsePanelAnimation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(2)),
                From = new Thickness(0f, _gdStocks.ActualHeight / 2f, 0f, 0f),
                To = new Thickness(0f, _gdStocks.ActualHeight / 1f, 0f, 0f),
                DecelerationRatio = 0.9f
            };

            Storyboard.SetTargetProperty(collapsePanelAnimation, new PropertyPath("Margin"));
            Storyboard sbCollapse = Resources["_sbcollapseEdit"] as Storyboard;
            sbCollapse.Completed += CollapseStoryboard;
            sbCollapse.Children.Add(collapsePanelAnimation);
            sbCollapse.Begin(_pnEditSection);
        }

        private void CollapseStoryboard(object sender, EventArgs args)
        {
            _pnEditSection.Visibility = Visibility.Collapsed;
        }

        /*private void TbStocks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_gdStocks.SelectedItem == null)
                return;
            Stock selectedStock = _gdStocks.SelectedItem as Stock;
            _currentStock = selectedStock;
            _pnEditSection.DataContext = _currentStock;
        }

        private void UpdateSource()
        {
            _tbName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbItemPrice.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbPrice.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbStockLeft.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbMarkup.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbPriceToMeetMark.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbDate.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbTargetSale.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void RestoreToOriginal()
        {
            _tbName.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbItemPrice .GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbStockLeft .GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbPrice.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbMarkup.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbPriceToMeetMark.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbDate.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbTargetSale.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }*/
    }
}
