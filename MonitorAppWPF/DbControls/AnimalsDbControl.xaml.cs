using MonitorAppWPF.UiConstants;
using PetsEntityLib.DataBaseContext;
using PetsEntityLib.DataBaseExtractions;
using PetsEntityLib.DataBasePersistances;
using PetsEntityLib.DataBaseUpdates;
using PetsEntityLib.Entities;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using TestCollectionLib;

namespace MonitorAppWPF.DbControls
{
    /// <summary>
    /// Interaction logic for AnimalsDbControl.xaml
    /// </summary>
    public partial class AnimalsDbControl : UserControl
    {
        public AnimalsDbControl()
        {
            InitializeComponent();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            this.ExpandEditPanel();
            _gdAnimals.IsEnabled = false;
            //_newEditwMode = Constants.Edit;
        }

        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            this.CollapseEditPanel();
        }

        private void CreateNewAnimal(Animal animal)
        {
            CreateAnimalClass createAnimal = new CreateAnimalClass(null);
            createAnimal.AddItem(animal);
            createAnimal.SaveCreatedItems();
            /*PersistEntityAsyncro asyncrosave = new PersistEntityAsyncro();
            asyncrosave.Save(TestOne.GenerateMultipleEntites);*/
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

            ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                From = new Thickness(0f, _gdAnimals.ActualHeight, 0f, 0f),
                To = new Thickness(0f, _gdAnimals.ActualHeight / 2f, 0f, 0f),
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
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                From = new Thickness(0f, _gdAnimals.ActualHeight / 2f, 0f, 0f),
                To = new Thickness(0f, _gdAnimals.ActualHeight / 1f, 0f, 0f),
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

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            _gdAnimals.IsEnabled = true;
            this.CollapseEditPanel();
        }
    }
}
