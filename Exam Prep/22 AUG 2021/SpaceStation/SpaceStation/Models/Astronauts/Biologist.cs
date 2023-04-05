using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double initialOxygenUnits = 70;
        public Biologist(string name) : base(name, initialOxygenUnits)
        {
        }

        public override void Breath()
        {
            this.Oxygen -= 5;
        }
    }
}
