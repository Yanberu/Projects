using Project_18.Animals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project_18
{
    public class AnimalRepository : IAnimalRepositoryControl
    {
        private ObservableCollection<IAnimalEntity> animals = new ObservableCollection<IAnimalEntity>()
        {
            new Mammal("Зубр",87654, true),
            new Bird("Журавль",524246, false),
            new Amphibian("Крокодил",10000, false)
        };

        public ObservableCollection<IAnimalEntity> Animals { get { return animals; } set { animals = value; } }


        public void AddAnimal(string Type,string Name, int Population, bool Status)
        {
            animals.Add(AnimalFactory.GetAnimal(Type, Name, Population, Status));
        }

        public void DeleteAnimal(IAnimalEntity animal)
        {
            animals.Remove(animal);
        }
    }
}
