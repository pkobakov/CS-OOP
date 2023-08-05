using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private ICollection<IMilitaryUnit> models;
        public UnitRepository() 
        {
            this.models = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => this.models.ToList().AsReadOnly();

        public void AddItem(IMilitaryUnit model)
        {
            this.models.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
           return this.models.FirstOrDefault( m => m.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            var model = FindByName(name);
            return this.models.Remove(model);
        }
    }
}
