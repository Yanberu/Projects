using Project_18.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_18
{
    public static class AnimalFactory
    {
        public static IAnimalEntity GetAnimal(string AnimalType,string Name,int Population, bool IsAlive)
        {
            switch(AnimalType)
            {
                case "Млекопитающие": return new Mammal(Name, Population, IsAlive);
                case "Птица": return new Bird(Name, Population, IsAlive);
                case "Рептилия": return new Amphibian(Name, Population, IsAlive);
                default:
                    {
                        MessageBox.Show("Вы ввели несуществующее семейство", "Ошибка");
                        return new NullAnimal();
                    } 
            }
        }
    }
}
