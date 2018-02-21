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
        public CustomerDBControl()
        {
            InitializeComponent();
        }

        private void BtnCreateNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.ExpandEditPanel();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var editBtn = sender as Button;
            if (editBtn != null)
            {
                //editBtn.Command.Execute(editBtn.CommandParameter);
                this.ExpandEditPanel();
            }
        }

        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            this.CollapseEditPanel();
        }

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
                From = new Thickness(0f, _lvCustomers.ActualHeight, 0f, 0f),
                To = new Thickness(0f, _lvCustomers.ActualHeight / 2f, 0f, 0f),
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
                From = new Thickness(0f, _lvCustomers.ActualHeight / 2f, 0f, 0f),
                To = new Thickness(0f, _lvCustomers.ActualHeight / 1f, 0f, 0f),
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
    }
}
