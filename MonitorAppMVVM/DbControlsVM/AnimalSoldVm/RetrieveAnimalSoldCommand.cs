using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.AnimalSoldVm
{
    public class RetrieveAnimalSoldCommand : ICommand
    {
        private AnimalSoldViewModel _animalSoldViewModel;

        public event EventHandler CanExecuteChanged;

        public RetrieveAnimalSoldCommand(AnimalSoldViewModel animalSoldViewModel)
        {
            _animalSoldViewModel = animalSoldViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //_animalSoldViewModel.AnimalSoldList =
            _animalSoldViewModel.AnimalSoldListAccessEnabled = true; 
        }
    }
}
