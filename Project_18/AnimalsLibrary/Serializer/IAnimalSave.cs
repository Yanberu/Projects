using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_18.Serializer
{
    public interface IAnimalSave
    {
        public void SaveAnimalToFile(IEnumerable<IAnimalEntity> animals);
    }
}
