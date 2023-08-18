using Project_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_19.Interfaces
{
    public interface IPersonCollection
    {
        public IEnumerable<Person> Persons { get; }
    }
}
