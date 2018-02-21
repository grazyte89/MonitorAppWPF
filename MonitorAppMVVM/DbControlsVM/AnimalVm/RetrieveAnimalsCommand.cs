using PetsEntityLib.DataBaseExtractions;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.AnimalVm
{
    public class RetrieveAnimalsCommand : ICommand
    {
        private AnimalViewModel _animalViewModel;

        public event EventHandler CanExecuteChanged;

        public RetrieveAnimalsCommand(AnimalViewModel animalViewModel)
        {
            _animalViewModel = animalViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                _animalViewModel.AnimalsList = 
                    new ObservableCollection<Animal>(RetrieveAnimals.GetAllAnimals());
                _animalViewModel.AnimalListAccessEnabled = true;
            }
            catch (Exception exception)
            {
                _animalViewModel.RaiseAnimalVmErrorMessage("Error encountered when retrieving animals " +
                    "from the database.");
            }
        }
    }
}
