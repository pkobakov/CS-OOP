using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Enums;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IDriver> drivers;
        private IRepository<ICar> cars;
        private IRepository<IRace> races;
        public ChampionshipController() 
        { 
            drivers = new DriverRepository();
            cars = new CarRepository();
            races = new RaceRepository();

        }
        //ready
        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!drivers.GetAll().Any( d => d.Name == driverName)) 
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if ( !cars.GetAll().Any(c => c.Model == carModel)) 
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            ICar car = cars.GetAll().FirstOrDefault( c => c.Model == carModel);
            IDriver driver = drivers.GetAll().FirstOrDefault( d => d.Name == driverName);

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }
        //ready
        public string AddDriverToRace(string raceName, string driverName)
        {
            if ( !races.GetAll().Any(r => r.Name == raceName) ) 
            { 
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (!drivers.GetAll().Any( d => d.Name == driverName)) 
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            IDriver driver = drivers.GetAll().FirstOrDefault( d => d.Name == driverName);
            IRace race = races.GetAll().FirstOrDefault( r => r.Name == raceName);

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }
        //ready
        public string CreateCar(string type, string model, int horsePower)
        {
            Enum.TryParse(type, out CarType carType);
            ICar car = carType switch
            {
                CarType.Muscle => new MuscleCar(model, horsePower),
                CarType.Sports => new SportsCar(model, horsePower),
                _ => throw new ArgumentException(ExceptionMessages.CarInvalid)
            };

            if (cars.GetAll().Any(c => c.Model == model && c.HorsePower == horsePower))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            cars.Add(car);
            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }
        //ready
        public string CreateDriver(string driverName)
        {
            if (drivers.GetAll().Any( d => d.Name == driverName)) 
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);
            drivers.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }
        //ready
        public string CreateRace(string name, int laps)
        {
            if ( races.GetAll().Any( r => r.Name == name && r.Laps == laps)) 
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            if ( !races.GetAll().Any( r => r.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (races.GetAll().FirstOrDefault( r => r.Name == raceName).Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            IRace race = races.GetAll().FirstOrDefault( r => r.Name == raceName);
            IList<IDriver> sorted = race.Drivers
                                        .ToList()
                                        .OrderByDescending( d => d.Car.CalculateRacePoints(race.Laps))
                                        .Take(3)
                                        .ToList();
            var sb = new StringBuilder();
            int counter = 1;
            foreach (var driver in sorted) 
            {
                if (counter == 1)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, driver.Name, race.Name));

                }

                if (counter == 2)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, driver.Name, race.Name));
                }

                if(counter == 3) 
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, driver.Name, race.Name));

                }
                   
                counter++;
            }
            
            races.Remove(race);



            return sb.ToString().Trim();
        }
    }
}
