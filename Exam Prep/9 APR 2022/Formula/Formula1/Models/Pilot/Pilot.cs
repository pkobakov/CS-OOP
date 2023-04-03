using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models.Pilot
{
    public class Pilot
    {
        private string fullName;
        private bool canRace;
        private IFormulaOneCar car;
        private int numberOfWins;

        public Pilot(string fullName)
        {
            this.FullName = fullName;
        }

        public string FullName 
        { 
            get => fullName;
            private set
            {
                if (value.Length < 5 || string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                fullName = value;
            }
        }

        public bool CanRace => false;
        
        public IFormulaOneCar Car 
        { 
            get => car;
            private set 
            { 
                if (value == null) 
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                car = value;
            }
        }

        public int NumberOfWins { get; private set; }

        public void AddCar(IFormulaOneCar car) 
        { 
            this.car = car;
            canRace = true;
        }

        public void WinRace() 
        {
            this.NumberOfWins++;
        }

        public override string ToString()
          => $"Pilot { this.FullName } has { this.NumberOfWins } wins." ;
        


    }
}
