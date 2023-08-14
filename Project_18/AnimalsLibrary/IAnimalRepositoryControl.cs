using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_18
{
    public interface IAnimalRepositoryControl
    {
        public void AddAnimal(string Type, string Name, int Population, bool Status);

        public void DeleteAnimal(IAnimalEntity animal);
    }
}
