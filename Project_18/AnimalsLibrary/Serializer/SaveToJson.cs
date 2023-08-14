using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project_18.Serializer
{
    public class SaveToJson : IAnimalSave
    {
        private string fileName;
        public SaveToJson(string fileName)
        {
            this.fileName = fileName;
        }

        public void SaveAnimalToFile(IEnumerable<IAnimalEntity> animals)
        {
             string serialize = JsonSerializer.Serialize(animals);
                File.WriteAllText($"{fileName}.json", serialize);
        }
    }
}
