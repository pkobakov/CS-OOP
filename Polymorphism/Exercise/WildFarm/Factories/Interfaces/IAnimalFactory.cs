using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Interfaces;

namespace WildFarm.Factories.Interfaces
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string[] args);
    }
}
