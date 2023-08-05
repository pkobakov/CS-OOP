using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Models
{
    public abstract class SandwichPrototype
    {
        public abstract SandwichPrototype Clone();
    }
}
