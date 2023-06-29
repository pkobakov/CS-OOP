using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rаiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name) 
            : base(name, 80)
        {
            
        }

        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
    }
}
