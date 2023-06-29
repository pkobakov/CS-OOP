using Rаiding.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rаiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        public BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }
        public string Name { get; private set; }

        public int Power { get; private set; }

        public abstract string CastAbility();
    }
}
