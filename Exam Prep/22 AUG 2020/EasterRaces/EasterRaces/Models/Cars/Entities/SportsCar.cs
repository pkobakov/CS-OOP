using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double cc = 3000;
        private const int minHP = 250;
        private const int maxHP = 450;
        public SportsCar(string model, int horsePower)
            : base(model, horsePower, cc, minHP, maxHP)
        {
        }
    }
}
