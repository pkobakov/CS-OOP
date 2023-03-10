using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Interfaces;

namespace WildFarm.Factories.Interfaces
{
    public interface IFoodFactory
    {
        IFood CreateFood(string type, int quantity);
    }
}
