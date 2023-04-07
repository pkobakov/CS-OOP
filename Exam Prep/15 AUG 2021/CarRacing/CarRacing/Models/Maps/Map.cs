using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable()) 
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable()) 
            { 
               return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username );
            
            }

            if (!racerTwo.IsAvailable()) 
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            racerOne.Race();
            racerTwo.Race();

            var racerOneCalculatedRacingBehavior = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            var chanceToRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneCalculatedRacingBehavior;

            var racerTwoCalculatedRacingBehavior = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;
            var chanceToRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoCalculatedRacingBehavior;

            IRacer winner = chanceToRacerOne > chanceToRacerTwo ? racerOne : racerTwo;

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);

        }

       


    }
}
