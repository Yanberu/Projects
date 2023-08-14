using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_18.Serializer
{
    public class DataSerializer
    {
        public IAnimalSave Mode { get; set; }
        public DataSerializer(IAnimalSave Method) 
        {
            Mode = Method;
        }

        public void Serialize(IEnumerable<IAnimalEntity> animals)
        {
            Mode.SaveAnimalToFile(animals);
        }
    }
}
