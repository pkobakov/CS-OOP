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
            if (racerOne != null && racerTwo != null) 
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (racerOne != null) 
            { 
               return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username );
            
            }

            if (racerTwo != null) 
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            var racerOneCalculatedRacingBehavior = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            var chanceToRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneCalculatedRacingBehavior;

            var racerTwoCalculatedRacingBehavior = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            var chanceToRacerTwo = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerTwoCalculatedRacingBehavior;

            IRacer winner = chanceToRacerOne > chanceToRacerTwo ? racerOne : racerTwo;

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);

        }

       


    }
}
