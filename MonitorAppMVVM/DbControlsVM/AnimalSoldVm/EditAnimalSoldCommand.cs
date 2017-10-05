using MonitorAppMVVM.DbControlsVM.AnimalSoldVm;
using MonitorAppMVVM.UiConstantsMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.AnimalSoldVm
{
    public class EditAnimalSoldCommand : ICommand
    {
        private AnimalSoldViewModel _animalSoldViewModel;

        public event EventHandler CanExecuteChanged;

        public EditAnimalSoldCommand(AnimalSoldViewModel animalSoldViewModel)
        {
            _animalSoldViewModel = animalSoldViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _animalSoldViewModel.ExistingOrNewModel = Constants.Edit;
            _animalSoldViewModel.AnimalSoldListAccessEnabled = false;
        }
    }
}
