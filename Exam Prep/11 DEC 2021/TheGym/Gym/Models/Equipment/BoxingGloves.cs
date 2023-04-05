using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double initialWeight = 227;
        private const decimal initialPrice = 120;
        public BoxingGloves() : base(initialWeight, initialPrice)
        {
        }
    }
}
