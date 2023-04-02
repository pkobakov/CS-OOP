using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private int damage = 20;
        public Claymore(string name, int durability) 
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            damage--;
            Durability--;
            return damage;

        }
    }
}
