using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private const int damage = 25;
        public Mace(string name, int durability) : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (this.Durability > 0)
            {
                this.Durability -= 1 ;

            }

            if (this.Durability == 0)
            {

                return 0;
            }

            return damage;
        }
    }
}
