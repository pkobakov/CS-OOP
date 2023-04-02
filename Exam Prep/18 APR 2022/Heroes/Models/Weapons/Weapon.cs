using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;
        public Weapon(string name, int durability) 
        {
            this.Name = name;
            this.Durability = durability;
        }
        public string Name 
        {
            get => name;
            private set 
            { 
                if (string.IsNullOrWhiteSpace(value)) 
                { 
                    throw new ArgumentException(ExceptionMessages.WeaponTypeNull);
                }
              this.name = value;
            }
        }

        public int Durability 
        { 
            get => durability;
            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurabilityBelowZero);
                }
                this.durability = value;
            }
        
        }

        public abstract int DoDamage();
    }
}
