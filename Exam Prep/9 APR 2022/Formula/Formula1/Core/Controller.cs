using Formula1.Core.Contracts;
using Formula1.Models.Contracts;
using Formula1.Models.FormulaOneCars;
using Formula1.Models.Pilot;
using Formula1.Models.Race;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = FindPilotByName(pilotName);
            var car = FindCarByModel(carModel);

            if ( pilot == null || pilot.Car != null) 
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (car == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            carRepository.Remove(car);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            

            if (!raceRepository.Models.Any(r => r.RaceName == raceName))
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (!pilotRepository.Models.Any(p => p.FullName == pilotFullName) )
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            var race = FindRaceByName(raceName);
            var pilot = FindPilotByName(pilotFullName);

            if (race.Pilots.Any( p => p.FullName == pilotFullName) || pilot.CanRace == false)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car;
            if (carRepository.Models.Any(p => p.Model == model))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            car = type switch 
            { 
              nameof(Ferrari) => new Ferrari(model, horsepower, engineDisplacement),
              nameof(Williams) => new Williams(model, horsepower, engineDisplacement),  
              _=> throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type))
            };

            carRepository.Add(car);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.Models.Any(p => p.FullName == fullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            IPilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race;

            if (raceRepository.Models.Any(p => p.RaceName == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            var sb = new StringBuilder();
            var sortedPilots = pilotRepository.Models.OrderByDescending( p => p.NumberOfWins).ToList();
            
            foreach (var pilot in sortedPilots) 
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().Trim();   
        }

        public string RaceReport()
        {
            var sb = new StringBuilder();
            var sortedRaces = raceRepository.Models.Where(r => r.TookPlace == true).ToList();

            foreach (var race in sortedRaces) 
            {
                sb.AppendLine(race.RaceInfo());
            
            }

            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            IRace race;

            if (!raceRepository.Models.Any(r => r.RaceName == raceName)) 
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            race = FindRaceByName(raceName);

            if (race.Pilots.Count < 3) 
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            
            var sb = new StringBuilder();
            var pilots = race.Pilots.OrderByDescending( p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3);
            int counter = 1;
            foreach (var pilot in pilots)
            {
                if (counter == 1) 
                {
                    sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, pilot.FullName, raceName));
                    pilot.WinRace();
                }
                if (counter == 2)
                {
                    sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, pilot.FullName, raceName));
                }
                if (counter == 3)
                {
                    sb.AppendLine(string.Format(OutputMessages.PilotThirdPlace, pilot.FullName, raceName));
                }
                counter++;
            }

            race.TookPlace = true;
            return sb.ToString().Trim();
        }

      

        private IFormulaOneCar FindCarByModel(string carModel)
        {
            return carRepository.Models.FirstOrDefault(c => c.Model == carModel);
        }

        private IRace FindRaceByName(string raceName)
        {
            return raceRepository.Models.FirstOrDefault(r => r.RaceName == raceName);
        }

        private IPilot FindPilotByName(string fullName)
        {
            return pilotRepository.Models.FirstOrDefault(r => r.FullName == fullName);
        }
    }
}
