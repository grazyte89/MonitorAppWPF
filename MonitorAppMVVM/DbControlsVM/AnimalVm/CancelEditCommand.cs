using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.AnimalVm
{
    public class CancelEditCommand : ICommand
    {
        private AnimalViewModel _animalViewModel;

        public event EventHandler CanExecuteChanged;

        public CancelEditCommand(AnimalViewModel animalViewModel)
        {
            _animalViewModel = animalViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _animalViewModel.CurrentAnimal = _animalViewModel.SelectedAnimal;
            _animalViewModel.AnimalListAccessEnabled = true;
        }
    }
}
