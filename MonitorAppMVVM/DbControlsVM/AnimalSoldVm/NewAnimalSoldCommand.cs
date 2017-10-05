using MonitorAppMVVM.UiConstantsMvvm;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.AnimalSoldVm
{
    public class NewAnimalSoldCommand : ICommand
    {
        private AnimalSoldViewModel _animalSoldViewModel;

        public event EventHandler CanExecuteChanged;

        public NewAnimalSoldCommand(AnimalSoldViewModel animalSoldViewModel)
        {
            _animalSoldViewModel = animalSoldViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _animalSoldViewModel.AnimalSoldListAccessEnabled = false;
            _animalSoldViewModel.ExistingOrNewModel = Constants.New;
            _animalSoldViewModel.CurrentAnimalSold = new AnimalSold();
        }
    }
}
