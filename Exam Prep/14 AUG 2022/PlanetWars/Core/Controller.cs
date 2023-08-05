using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planets;
        public Controller() 
        { 
           this.planets = new PlanetRepository();   
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            IMilitaryUnit unit;

            if (planet == null) 
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Any( u => u.GetType().Name == unitTypeName)) 
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            unit = unitTypeName switch
            { 
               nameof(AnonymousImpactUnit) => new AnonymousImpactUnit(),
               nameof(SpaceForces) => new SpaceForces(),
               nameof(StormTroopers) => new StormTroopers(),
               _=> throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName))
            };

            
            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);


        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            IWeapon weapon;

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(u => u.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            weapon = weaponTypeName switch
            {
               nameof(BioChemicalWeapon) => new BioChemicalWeapon(destructionLevel),
               nameof(NuclearWeapon) => new NuclearWeapon(destructionLevel),    
               nameof(SpaceMissiles) => new SpaceMissiles(destructionLevel),
               _=> throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName))
            };

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);


        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = planets.FindByName(name);

            if (planet != null) 
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            planet = new Planet(name, budget);
            planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);

        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planets.Models
                .OrderByDescending( p => p.MilitaryPower)
                .ThenBy(p => p.Name)


                ) 
            {

                sb.AppendLine(planet.PlanetInfo()); 
            
            }

            return sb.ToString().Trim();   
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet planet1 = planets.FindByName(planetOne);
            IPlanet planet2 = planets.FindByName(planetTwo);

            IPlanet winner = null;
            IPlanet loser = null;

            if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if (planet1.Weapons.Any( w => w.GetType().Name == nameof(NuclearWeapon)) &&
                    !planet2.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    loser = planet2;
                    winner = planet1;   
                }

                if (planet2.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) &&
                    !planet1.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    loser = planet1;
                    winner = planet2;
                }

                if ((planet1.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) &&
                    planet2.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))) 
                    
                    || 

                    (!planet1.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) &&
                    !planet2.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))))
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);

                    return OutputMessages.NoWinner;
                }

            }

            winner = planet1.MilitaryPower > planet2.MilitaryPower ? planet1 : planet2;
            loser = planet2.MilitaryPower < planet1.MilitaryPower ? planet2 : planet1;

            winner.Spend(winner.Budget / 2);
            winner.Profit(loser.Budget / 2);


            var forcesCosts = loser.Army.Sum(u => u.Cost);
            var weaponsPrices = loser.Weapons.Sum(w => w.Price);

            winner.Profit(forcesCosts);
            winner.Profit(weaponsPrices);


            planets.RemoveItem(loser.Name);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);

        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);


        }
    }
}
