using MonitorAppMVVM.UiConstantsMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.AnimalVm
{
    public class EditAnimalCommand : ICommand
    {
        public AnimalViewModel _animalViewModel;

        public event EventHandler CanExecuteChanged;

        public EditAnimalCommand(AnimalViewModel animalViewModel)
        {
            _animalViewModel = animalViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _animalViewModel.AnimalListAccessEnabled = false;
            _animalViewModel.ExistingOrNewAnimal = Constants.Edit;
        }
    }
}
