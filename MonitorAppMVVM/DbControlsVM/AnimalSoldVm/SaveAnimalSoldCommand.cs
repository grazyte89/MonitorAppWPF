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

namespace MonitorAppMVVM.DbControlsVM.AnimalSoldVm
{
    public class SaveAnimalSoldCommand : ICommand
    {
        private AnimalSoldViewModel _animalSoldViewModel;

        public event EventHandler CanExecuteChanged;

        public SaveAnimalSoldCommand(AnimalSoldViewModel animalSoldViewModel)
        {
            _animalSoldViewModel = animalSoldViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_animalSoldViewModel.ExistingOrNewModel.Equals(Constants.New))
                this.CreateNewAnimalSold(_animalSoldViewModel.CurrentAnimalSold);
            else if (_animalSoldViewModel.ExistingOrNewModel.Equals(Constants.Edit)
                && _animalSoldViewModel.CurrentAnimalSold != null)
                this.UpdateAnimalSold(_animalSoldViewModel.CurrentAnimalSold);
        }

        private void CreateNewAnimalSold(AnimalSold animalSold)
        {
            CreateAnimalsSoldClass animalSoldClass = new CreateAnimalsSoldClass(null);
            animalSoldClass.AddItem(animalSold);
            animalSoldClass.SaveCreatedItems();
        }

        private void UpdateAnimalSold(AnimalSold animalSold)
        {
            UpdateAnimalSoldClass updateAnimlSold = new UpdateAnimalSoldClass(animalSold);
            updateAnimlSold.SaveUpdate();
        }
    }
}