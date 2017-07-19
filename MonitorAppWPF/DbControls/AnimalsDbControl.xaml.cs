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
        private Animal _currentAnimal;
        private string _newEditwMode;

        public AnimalsDbControl()
        {
            InitializeComponent();
        }

        private void TbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_gdAnimals.SelectedItem == null)
                return;
            Animal selectedAnimal = _gdAnimals.SelectedItem as Animal;
            _currentAnimal = selectedAnimal;
            _pnEditSection.DataContext = _currentAnimal;
        }

        private void BtnAnimals_Click(object sender, RoutedEventArgs e)
        {
            _gdAnimals.DataContext = RetrieveAnimals.GetAllAnimals();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            this.ExpandEditPanel();
            _gdAnimals.IsEnabled = false;
            _newEditwMode = Constants.Edit;
        }

        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            if (_currentAnimal == null)
                return;
            this.UpdateSource();
            if (_newEditwMode.Equals(Constants.New))
                this.CreateNewAnimal(_currentAnimal);
            else if (_newEditwMode.Equals(Constants.Edit))
                this.UpdateAnimal(_currentAnimal);
            _gdAnimals.IsEnabled = true;
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
            _currentAnimal = new Animal();
            _pnEditSection.DataContext = _currentAnimal;
            _newEditwMode = Constants.New;
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
            this.RestoreToOriginal();
            _currentAnimal = null;
            _gdAnimals.IsEnabled = true;
            this.CollapseEditPanel();
        }

        private void UpdateSource()
        {
            _tbName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbAge.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbGender.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbStatus.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbType.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbCheckup.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            _tbVacination.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void RestoreToOriginal()
        {
            //BindingOperations.GetBindingExpression(_tbName, TextBox.TextProperty).UpdateSource();
            _tbIdentityNo.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbName.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbAge.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbGender.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbStatus.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbType.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbCheckup.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _tbVacination.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
        }
    }
}
