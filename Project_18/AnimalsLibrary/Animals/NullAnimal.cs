using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_18.Animals
{
    public class NullAnimal : IAnimalEntity
    {
        public string Name { get ; set ; }
        public int Population { get ; set ; }
        public bool IsAlive { get; set; }

        public string Family => FormFamilyString();

        public NullAnimal()
        {
            Name = "Null";
            Population= 0;
            IsAlive = false;
        }
        public string FormFamilyString()
        {
            return "Null";
        }
    }
}
