using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.AnimalVm
{
    public class AnimalListDropCommand : ICommand
    {
        private AnimalViewModel _animalViewModel;

        public event EventHandler CanExecuteChanged;

        public AnimalListDropCommand(AnimalViewModel animalViewModel)
        {
            _animalViewModel = animalViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_animalViewModel.SelectedBufferAnimal == null)
            {
                return;
            }

            try
            {
                var alreaadyExist = _animalViewModel.AnimalsList
                        .Any(a => a.ID == _animalViewModel.SelectedBufferAnimal.ID);
                if (!alreaadyExist)
                {
                    _animalViewModel.AnimalsList.Add(_animalViewModel.SelectedBufferAnimal);
                    _animalViewModel.AnimalBufferList.Remove(_animalViewModel.SelectedBufferAnimal);
                }
            }
            catch (Exception exception)
            {
                _animalViewModel.RaiseAnimalVmErrorMessage("Error encountered when drop animal to animal-list.");
            }
        }
    }
}