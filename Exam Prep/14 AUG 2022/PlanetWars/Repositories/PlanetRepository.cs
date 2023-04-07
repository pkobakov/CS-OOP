using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private ICollection<IPlanet> models;
        public PlanetRepository() 
        {
            models = new List<IPlanet>();   
        }
        public IReadOnlyCollection<IPlanet> Models => this.models.ToList().AsReadOnly();

        public void AddItem(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.models.FirstOrDefault( m => m.Name == name);
        }

        public bool RemoveItem(string name)
        {
            var model = FindByName(name);   
            return this.models.Remove(model);
        }
    }
}
