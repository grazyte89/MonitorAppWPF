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
        //private volatile bool _tbCustomer2Collapsed;

        public AnimalsDbControl()
        {
            InitializeComponent();
        }

        private void TbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // seection
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            _gdCustomers.DataContext = RetrieveAnimals.GetAllAnimals();

            /*PersistEntityAsyncro _asyncro = new PersistEntityAsyncro();
            _asyncro.Save(GenerateAnimlas());*/
        }

        private List<Animal> GenerateAnimlas()
        {
            List<Animal> animals = new List<Animal>();

            for (int index = 0; index < 1000; index++)
            {
                animals.Add(new Animal {
                    NAME = "test gene 1",
                    GENDER = "male",
                    AGE = 45,
                    TYPE = "donkey test",
                    STATUS = "test alive"
                });
            }

            return animals;
        }


        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            _pnEditSection.Visibility = Visibility.Visible;
            ShowHideMenu("_sbExpandEdit", _btnSaveEdit, _pnEditSection);
        }

        private void ShowHideMenu(string storyboard, Button saveEditBtn, StackPanel editPanel)
        {
            Storyboard sb = Resources[storyboard] as Storyboard;
            sb.Begin(editPanel);

            if (storyboard.Contains("Show"))
            {
                saveEditBtn.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
