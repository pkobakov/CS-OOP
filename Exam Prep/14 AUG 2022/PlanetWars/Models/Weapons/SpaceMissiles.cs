using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetWars.Models.Weapons
{
    public class SpaceMissiles : Weapon
    {
        public SpaceMissiles(int destructionLevel) 
            : base(destructionLevel, 8.75)
        {
        }
    }
}
