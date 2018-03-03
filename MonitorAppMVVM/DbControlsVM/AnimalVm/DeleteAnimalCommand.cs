using PetsEntityLib.DataBaseDeletions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.AnimalVm
{
    public class DeleteAnimalCommand : ICommand
    {
        private AnimalViewModel _animalViewModel;

        public event EventHandler CanExecuteChanged;

        public DeleteAnimalCommand(AnimalViewModel animalViewModel)
        {
            _animalViewModel = animalViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.ExecuteBusinessLogic();
        }

        private void ExecuteBusinessLogic()
        {
            if (_animalViewModel.AnimalBufferList == null
                || _animalViewModel.AnimalBufferList.Count < 1)
            {
                return;
            }
            DeleteAnimalClass deleteAnimals = new DeleteAnimalClass(_animalViewModel.AnimalBufferList);
            if (!deleteAnimals.DeleteItems(out string message))
            {
                _animalViewModel.RaiseAnimalVmErrorMessage(message);
            }
        }
    }
}
