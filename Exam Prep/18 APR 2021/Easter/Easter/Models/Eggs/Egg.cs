using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;
        public Egg(string name, int energyRequired) 
        { 
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }
        public string Name 
        { 
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }
                name = value; 
            }
        }

        public int EnergyRequired 
        {
            get {  return energyRequired; } 
            private set 
            {
                if (value < 0)
                {
                    energyRequired = 0;
                }

                energyRequired = value;
            }
        }

        public void GetColored()
        {
            this.EnergyRequired -= 10;

            if (this.EnergyRequired < 0) 
            {
                this.EnergyRequired = 0;
            }
        }

        public bool IsDone()
        {
            if (this.energyRequired == 0)
            {
                return true;
            }
            return false;
        }
    }
}
