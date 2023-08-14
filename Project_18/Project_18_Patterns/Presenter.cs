using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_18;
using Project_18.Serializer;

namespace Project_18_Patterns
{
    public class Presenter
    {
        public AnimalRepository? Repository { get; set; } = new AnimalRepository();
        DataSerializer ds;
        public IAnimalRepositoryControl RepositoryControl;

        public Presenter()
        {
            RepositoryControl = Repository;
        }
        public void AddAnimal(string Type, string Name, int Population, bool IsAlive)
        {
            Repository.Animals.Add(AnimalFactory.GetAnimal(Type, Name, Population, IsAlive));
        }

        public void UpdateTxt()
        {
            var TxTSave = new SaveToTxt("animals");
            ds = new DataSerializer(TxTSave);
            ds.Serialize(Repository.Animals);
        }

        public void UpdateJson()
        {
            var JsonSave = new SaveToJson("animals");
            ds = new DataSerializer(JsonSave);
            ds.Serialize(Repository.Animals);
        }
        
    }
}
