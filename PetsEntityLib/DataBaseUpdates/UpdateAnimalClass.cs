using PetsEntityLib.DataBaseContext;
using PetsEntityLib.DataBaseValues;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBaseUpdates
{
    public class UpdateAnimalClass : IDBUpdate
    {
        private Animal _currentAnimal;

        public UpdateAnimalClass(Animal animal)
        {
            _currentAnimal = animal;
        }

        public void UpdateName(string name)
        {
            if (_currentAnimal != null)
                _currentAnimal.NAME = name;
        }

        public void UpdateAge(int age)
        {
            if (_currentAnimal != null)
                _currentAnimal.AGE = age;
        }

        public void UpdateGender(string gender)
        {
            gender = gender.ToLower();
            if (_currentAnimal != null)
                this.AssignGender(gender);
        }

        private void AssignGender(string gender)
        {
            switch (gender)
            {
                case "male":
                    _currentAnimal.GENDER = DbConstantsEnums.Male;
                    break;
                case "female":
                    _currentAnimal.GENDER = DbConstantsEnums.Female;
                    break;
                default:
                    break;
            }
        }

        public void UpdateVacination(DateTime datetime)
        {
            if (_currentAnimal != null)
                _currentAnimal.VACINATION = datetime;
        }

        private void UpdateType(string type)
        {
            if (_currentAnimal != null)
                _currentAnimal.TYPE = type;
        }

        private void UpdateStatus(string status)
        {
            if (_currentAnimal != null)
                _currentAnimal.STATUS = status;
        }

        public void SaveUpdate()
        {
            using (PetShopDBContext _context = new PetShopDBContext())
            {
                if (_currentAnimal == null)
                    return;
                _context.Entry(_currentAnimal).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
