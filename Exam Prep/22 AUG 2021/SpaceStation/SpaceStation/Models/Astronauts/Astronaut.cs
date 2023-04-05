using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private bool canBreath;
        private IBag bag;
        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
        }
        public string Name 
        {
            get => name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                { 
                     throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                 name = value;
            }
        }

        public double Oxygen 
        {
            get => oxygen; 
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                oxygen = value;
            }
        }

        public bool CanBreath { get => canBreath; private set { canBreath = value; } } 

        public IBag Bag { get => bag; private set { bag = value; } }

        public virtual void Breath()
        {
            if (this.Oxygen < 0) 
            {
                this.CanBreath = false;
            }
            oxygen -= 10;
        }
    }
}
