using MonitorAppWPF.UiConstants;
using PetsEntityLib.DataBaseExtractions;
using PetsEntityLib.DataBasePersistances;
using PetsEntityLib.DataBaseUpdates;
using PetsEntityLib.Entities;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MonitorAppWPF.DbControls
{
    /// <summary>
    /// Interaction logic for CustomerDBControl.xaml
    /// </summary>
    public partial class CustomerDBControl : UserControl
    {
        //private Customer _currentCustomer;
        //private string _newEditwMode;

        public CustomerDBControl()
        {
            InitializeComponent();
        }

        private void BtnCustomers_Click(object sender, RoutedEventArgs e)
        {
            //_gdCustomers.DataContext = RetrieveCustomers.GetAllCustomers();
        }

        private void BtnCreateNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.ExpandEditPanel();
            /*_currentCustomer = new Customer();
            _pnEditSection.DataContext = _currentCustomer;
            _newEditwMode = Constants.New;*/
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var editBtn = sender as Button;
            if (editBtn != null)
            {
                //editBtn.Command.Execute(editBtn.CommandParameter);
                this.ExpandEditPanel();
            }
            /*_gdCustomers.IsEnabled = false;
            _newEditwMode = Constants.Edit;*/
        }

        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            /*if (_currentCustomer == null)
                return;
            //this.UpdateSource();
            if (_newEditwMode.Equals(Constants.New))
                this.CreateNewCustomer(_currentCustomer);
            else if (_newEditwMode.Equals(Constants.Edit) && _currentCustomer != null)
                this.UpdateCustomer(_currentCustomer);
            _gdCustomers.IsEnabled = true;*/
            this.CollapseEditPanel();
        }

        /*private void CreateNewCustomer(Customer customer)
        {
            CreateCustomersClass createCustomer = new CreateCustomersClass(null);
            createCustomer.AddItem(customer);
            createCustomer.SaveCreatedItems();
        }

        private void UpdateCustomer(Customer customer)
        {
            UpdateCustomerClass updateCustomer = new UpdateCustomerClass(customer);
            updateCustomer.SaveUpdate();
        }*/

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            //this.RestoreToOriginal();
            //_currentCustomer = null;
            //_gdCustomers.IsEnabled = true;
            this.CollapseEditPanel();
        }

        private void ExpandEditPanel()
        {
            _pnEditSection.Visibility = Visibility.Visible;

            ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(2)),
                From = new Thickness(0f, _gdCustomers.ActualHeight, 0f, 0f),
                To = new Thickness(0f, _gdCustomers.ActualHeight / 2f, 0f, 0f),
                DecelerationRatio = 0.9f
            };

            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard sbEditSection = Resources["_sbExpandEdit"] as Storyboard;
            sbEditSection.Children.Add(thicknessAnimation);
            sbEditSection.Begin(_pnEditSection);
        }

        private void CollapseEditPanel()
        {
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(2)),
                From = new Thickness(0f, _gdCustomers.ActualHeight / 2f, 0f, 0f),
                To = new Thickness(0f, _gdCustomers.ActualHeight / 1f, 0f, 0f),
                DecelerationRatio = 0.9f
            };

            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard sbEditSection = Resources["_sbcollapseEdit"] as Storyboard;           
            sbEditSection.Completed += CollapseStoryboard;
            sbEditSection.Children.Add(thicknessAnimation);
            sbEditSection.Begin(_pnEditSection);
        }

        private void CollapseStoryboard(object sender, EventArgs args)
        {
            _pnEditSection.Visibility = Visibility.Collapsed;
        }

        private void TbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*if (_gdCustomers.SelectedItem == null)
                return;
            Customer selectedCustomer = _gdCustomers.SelectedItem as Customer;
            _currentCustomer = selectedCustomer;
            _pnEditSection.DataContext = _currentCustomer;*/
        }

        /*private void UpdateSource()
        {
            _tbFirstName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbLastName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbAge.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbAddress.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void RestoreToOriginal()
        {
            _tbFirstName.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbLastName.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbAge.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbAddress.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
        }*/
    }
}
