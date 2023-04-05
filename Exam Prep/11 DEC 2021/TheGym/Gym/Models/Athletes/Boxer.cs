using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int initialStamina = 60;
        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, initialStamina)
        {
        }

        public override void Exercise()
        {
            if (this.Stamina > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
            this.Stamina += 15;
        }
    }
}
