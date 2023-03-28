using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double cc = 5000;
        private const int minHP = 400;
        private const int maxHP = 600;
        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, cc, minHP, maxHP)
        {
        }
    }
}
