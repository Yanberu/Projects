using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_18.Serializer
{
    public class SaveToTxt : IAnimalSave
    {
        private string fileName;
        public SaveToTxt(string fileName)
        {
            this.fileName = fileName;
        }

        public void SaveAnimalToFile(IEnumerable<IAnimalEntity> animals)
        {
            using (StreamWriter fs = new StreamWriter($"{fileName}.txt"))
            {
                foreach(var animal in animals)
                {
                    fs.WriteLine($"Семейство {animal.Family}, Имя {animal.Name}, Популяция {animal.Population}, Красная книга {animal.IsAlive}");
                }
            }
        }
    }
}
