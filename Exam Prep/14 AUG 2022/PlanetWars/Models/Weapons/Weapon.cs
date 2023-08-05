using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destructionLevel;
        public Weapon(int destructionLevel, double price)
        {
            this.Price = price;
            this.DestructionLevel = destructionLevel;
        }
        public double Price 
        { 
           get { return price; }
           private set 
           {
                
                price = value; 
           }
        }

        public int DestructionLevel 
        {
            get { return destructionLevel; }
            private set
            {
                if (value < 1 )
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }

                if (value > 10 ) 
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }

                destructionLevel = value;
            }

        }
    }
}
 