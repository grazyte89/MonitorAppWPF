using PetsEntityLib.DataBaseContext;
using PetsEntityLib.DataBaseExtractions;
using PetsEntityLib.DataBasePersistances;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Xml.Serialization;
using XmlPersistanceLib;
using XmlPersistanceLib.Extractions;
using XmlPersistanceLib.Persistances;

namespace MonitorAppWPF.DbControls
{
    /// <summary>
    /// Interaction logic for AnimalsDbControl.xaml
    /// </summary>
    public partial class AnimalsDbControl : UserControl
    {
        private Animal _currentAnimal;
        //private IList<Animal> _newAnimals;

        public AnimalsDbControl()
        {
            InitializeComponent();
        }

        private void TbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Animal selectedAnimal = e.Source as Animal;
            _currentAnimal = selectedAnimal;
            _pnEditSection.DataContext = _currentAnimal;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            _gdAnimals.DataContext = RetrieveAnimals.GetAllAnimals();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            this.ExpandEditPanel();
            _gdAnimals.IsEnabled = false;
        }

        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            //BindingOperations.GetBindingExpression(_tbName, TextBox.TextProperty).UpdateSource();
            if (_currentAnimal == null)
                return;
            this.CreateNewAnimal(_currentAnimal);
            _gdAnimals.IsEnabled = true;
            this.CollapseEditPanel();
        }

        private void CreateNewAnimal(Animal animal)
        {
            CreateAnimalClass createAnimal = new CreateAnimalClass(null);
            createAnimal.AddItem(animal);
            createAnimal.SaveCreatedItems();
        }

        private void BtnCreateNewAnimal(object sender, RoutedEventArgs e)
        {
            this.ExpandEditPanel();
            _currentAnimal = new Animal();
            _pnEditSection.DataContext = _currentAnimal;
        }

        private void ExpandEditPanel()
        {
            _pnEditSection.Visibility = Visibility.Visible;
            Storyboard sbEditSection = Resources["_sbExpandEdit"] as Storyboard;
            sbEditSection.Begin(_pnEditSection);
        }

        private void CollapseEditPanel()
        {
            _pnEditSection.Visibility = Visibility.Collapsed;
            Storyboard sbEditSection = Resources["_sbcollapseEdit"] as Storyboard;
            sbEditSection.Begin(_pnEditSection);
        }
    }
}
