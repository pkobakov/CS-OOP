using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double initialWeight = 10000;
        private const decimal initialPrice = 80;
        public Kettlebell() : base(initialWeight, initialPrice)
        {
        }
    }
}
