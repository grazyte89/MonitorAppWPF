using MonitorAppMVVM.UiConstantsMvvm;
using PetsEntityLib.DataBasePersistances;
using PetsEntityLib.DataBaseUpdates;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.AnimalVm
{
    public class SaveAnimalCommand : ICommand
    {
        private AnimalViewModel _animalViewModel;

        public event EventHandler CanExecuteChanged;

        public SaveAnimalCommand(AnimalViewModel animalViewModel)
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
                this.ExecuteBusinessLogic();
            }
            catch (Exception exception)
            {
                _animalViewModel.RaiseAnimalVmErrorMessage("Error encountered when saving animal to the " +
                    "database.");
            }
        }

        private void CreateNewAnimal(Animal animal)
        {
            CreateAnimalClass createAnimal = new CreateAnimalClass(null);
            createAnimal.AddItem(animal);
            createAnimal.SaveCreatedItems();
        }

        private void UpdateAnimal(Animal animal)
        {
            UpdateAnimalClass updateAnimal = new UpdateAnimalClass(animal);
            updateAnimal.SaveUpdate();
        }

        private void ExecuteBusinessLogic()
        {
            if (_animalViewModel.ExistingOrNewAnimal.Equals(Constants.New))
            {
                this.CreateNewAnimal(_animalViewModel.CurrentAnimal);
                _animalViewModel.AnimalsList.Add(_animalViewModel.CurrentAnimal);
            }
            else if (_animalViewModel.ExistingOrNewAnimal.Equals(Constants.Edit)
                && _animalViewModel.CurrentAnimal != null)
            {
                this.UpdateAnimal(_animalViewModel.CurrentAnimal);
            }
        }
    }
}
