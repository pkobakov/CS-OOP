using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        string motivation;
        private int numberOfMedals;
        private int stamina;
        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.NumberOfMedals = numberOfMedals;
            this.Stamina = stamina;
        }
        public string FullName 
        { 
            get { return fullName; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }
                fullName = value; 
            }
        }

        public string Motivation 
        { 
            get { return motivation; }
            private set 
            {
                if (string.IsNullOrEmpty(value)) 
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }
                motivation = value;
            }
        }

        public int Stamina { get; protected set; }

        public int NumberOfMedals 
        {
            get { return numberOfMedals; }
            private set 
            { 
                if ( value < 0) 
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }
                numberOfMedals = value;
            }
        }

        public virtual void Exercise()
        {
            this.Stamina++;
        }
    }
}
