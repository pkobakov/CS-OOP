using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronauts;
        private IRepository<IPlanet> planets;
        private int exploredPlanets = 0;
        public Controller() 
        { 
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        } 
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            astronaut = type switch
            {
                nameof(Meteorologist) => new Meteorologist(astronautName),
                nameof(Biologist) => new Biologist(astronautName),
                nameof(Geodesist) => new Geodesist(astronautName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType)
            }; 

             astronauts.Add(astronaut);
             return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            
            foreach (var item in items) 
            { 
                     planet.Items.Add(item);
            }

            planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
            

        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            List<IAstronaut> suitableAstronauts = astronauts.Models.Where(a => a.Oxygen > 60).ToList();

            if (!suitableAstronauts.Any()) 
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IMission mission = new Mission();
            mission.Explore(planet, suitableAstronauts);

            var deadAstronauts = suitableAstronauts.Where(a => a.CanBreath == false);

            exploredPlanets++;
            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts.Count());

        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");


            foreach (var astronaut in astronauts.Models)
            {
                    sb.AppendLine($"Name: {astronaut.Name}");
                    sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                    string items = astronaut.Bag.Items.Count > 0 ? string.Join(", ", astronaut.Bag.Items) : "none";
                    sb.AppendLine($"Bag items: {items}");
            }
            
            

            return sb.ToString().Trim();   
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null) 
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);


        }
    }
}
