using MonitorAppMVVM.DbControlsVM.AnimalVm;
using MonitorAppMVVM.VmSharedGeneric;
using MonitorAppWPF.UiConstants;
using MonitorAppWPF.UiHelpResource;
using PetsEntityLib.DataBaseContext;
using PetsEntityLib.DataBaseExtractions;
using PetsEntityLib.DataBasePersistances;
using PetsEntityLib.DataBaseUpdates;
using PetsEntityLib.Entities;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using TestCollectionLib;

namespace MonitorAppWPF.DbControls
{
    /// <summary>
    /// Interaction logic for AnimalsDbControl.xaml
    /// </summary>
    public partial class AnimalsDbControl : UserControl
    {
        private bool _editSectionOpen = false;

        public AnimalsDbControl()
        {
            InitializeComponent();
            if (this.DataContext is AnimalViewModel animalViewModel)
            {
                animalViewModel.AnimalVmErrorMessage += AnimalViewModel_AnimalVmErrorMessage;
            }
        }

        private void AnimalViewModel_AnimalVmErrorMessage(object sender, ViewModelMessageEventArgs args)
        {
            MessageBox.Show(args.ErrorMessage);
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            this.ExpandEditPanel();
            //_lvAnimals.IsEnabled = false;
            //_newEditwMode = Constants.Edit;
        }

        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            this.CollapseEditPanel();
            //_lvAnimals.IsEnabled = true;
        }

        private void UpdateAnimal(Animal animal)
        {
            UpdateAnimalClass updateAnimal = new UpdateAnimalClass(animal);
            updateAnimal.SaveUpdate();
        }

        private void BtnCreateNewAnimal_Click(object sender, RoutedEventArgs e)
        {
            this.ExpandEditPanel();
        }

        private void ExpandEditPanel()
        {
            _pnEditSection.Visibility = Visibility.Visible;

            if (_editSectionOpen)
            {
                return;
            }

            ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                From = new Thickness(0f, _lvAnimals.ActualHeight, 0f, 0f),
                To = new Thickness(0f, _lvAnimals.ActualHeight / 2f, 0f, 0f),
                DecelerationRatio = 0.9f
            };

            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard sbEditSection = Resources["_sbExpandEdit"] as Storyboard;
            sbEditSection.Children.Add(thicknessAnimation);
            sbEditSection.Begin(_pnEditSection);
            _editSectionOpen = true;
        }

        private void CollapseEditPanel()
        {
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                From = new Thickness(0f, _lvAnimals.ActualHeight / 2f, 0f, 0f),
                To = new Thickness(0f, _lvAnimals.ActualHeight / 1f, 0f, 0f),
                DecelerationRatio = 0.9f
            };

            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard sbEditSection = Resources["_sbcollapseEdit"] as Storyboard;
            sbEditSection.Completed += CollapseStoryboard;
            sbEditSection.Children.Add(thicknessAnimation);
            sbEditSection.Begin(_pnEditSection);
            _editSectionOpen = false;
        }

        private void CollapseStoryboard(object sender, EventArgs args)
        {
            _pnEditSection.Visibility = Visibility.Collapsed;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            //_lvAnimals.IsEnabled = true;
            this.CollapseEditPanel();
        }

        private void LvAnimals_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender != null && e.LeftButton == MouseButtonState.Pressed)
            {
                var listView = sender as ListView;
                ListViewItem listViewItem = FindAncestorClass.FindAnchestor<ListViewItem>(e.OriginalSource as DependencyObject);
                Animal animal = listView.ItemContainerGenerator.ItemFromContainer(listViewItem) as Animal;
                DataObject dragData = new DataObject("myFormat", animal);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }

        private void LvAnimalBufferList_Drop(object sender, DragEventArgs e)
        {
            /*if (e.Data.GetDataPresent("myFormat"))
            {
                Animal animal = e.Data.GetData("myFormat") as Animal;
                ListView listView = sender as ListView;
                listView.Items.Add(animal);
            }
            if (this.DataContext is AnimalViewModel viewModel)
            {
                viewModel.AnimalObjectDropped();
            }*/
        }

        private void _lvAnimalBufferList_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender != null && e.LeftButton == MouseButtonState.Pressed)
            {
                var listView = sender as ListView;
                ListViewItem listViewItem = FindAncestorClass.FindAnchestor<ListViewItem>(e.OriginalSource as DependencyObject);
                Animal animal = listView.ItemContainerGenerator.ItemFromContainer(listViewItem) as Animal;
                DataObject dragData = new DataObject("myFormat", animal);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }
    }
}
