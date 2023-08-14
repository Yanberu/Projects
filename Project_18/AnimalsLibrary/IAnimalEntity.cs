using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_18
{
    public interface IAnimalEntity
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public bool IsAlive { get; set; }

        public string Family { get;}
        string FormFamilyString();
    }
}
