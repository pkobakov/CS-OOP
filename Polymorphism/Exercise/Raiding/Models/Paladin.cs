using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rаiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name, 100)
        {
          
        }

        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
    }
}
