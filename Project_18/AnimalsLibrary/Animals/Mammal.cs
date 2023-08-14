using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_18.Animals
{
    public class Mammal : IAnimalEntity
    {
        public string Name { get ; set ; }
        public int Population { get ; set ; }
        public bool IsAlive { get; set; }

        public string Family { get { return FormFamilyString(); } }

        public Mammal(string name, int population, bool isAlive)
        {
            Name = name;
            Population = population;
            IsAlive = isAlive;
        }

        public string FormFamilyString()
        {
            return "Млекопитающее";
        }
    }
}
