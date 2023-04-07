using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        public BioChemicalWeapon(int destructionLevel)
            : base(destructionLevel, 3.2)
        {
        }
    }
}
