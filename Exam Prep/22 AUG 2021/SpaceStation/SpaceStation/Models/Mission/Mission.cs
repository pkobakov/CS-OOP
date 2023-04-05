using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public Mission() { }
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts) 
            { 
                 while (astronaut.CanBreath) 
                 {
                    foreach (var item in planet.Items)
                    {
                        astronaut.Bag.Items.Add(item);
                        planet.Items.Remove(item);
                        astronaut.Breath();
                    }
                 }
            }
            
        }
    }
}
