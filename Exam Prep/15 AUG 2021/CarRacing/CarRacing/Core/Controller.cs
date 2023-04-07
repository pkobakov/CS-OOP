using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        IMap map;
        public Controller() 
        { 
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = type switch 
            { 
               nameof(SuperCar) => new SuperCar(make, model, VIN, horsePower),
               nameof(TunedCar) => new TunedCar(make, model, VIN, horsePower),
               _=> throw new ArgumentException(ExceptionMessages.InvalidCarType)
            };

            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model,  VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);
           
            if ( car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

           
            IRacer racer = type switch 
            { 
               nameof(ProfessionalRacer) => new ProfessionalRacer(username, car),   
               nameof(StreetRacer) => new StreetRacer(username, car),
               _=> throw new ArgumentException(ExceptionMessages.InvalidRacerType)
            };

            racers.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);


            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            
            string result = this.map.StartRace(racerOne, racerTwo);

            return result;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var racer in racers.Models.
                                OrderByDescending(d => d.DrivingExperience)
                                .ThenBy(d => d.Username).ToList())
            {
                
                sb.AppendLine (racer.ToString());
            }

            return sb.ToString().Trim();   
        }
    }
}
