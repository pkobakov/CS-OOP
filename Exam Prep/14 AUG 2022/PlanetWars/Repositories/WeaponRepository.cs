using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private ICollection<IWeapon> models;
        public WeaponRepository() 
        { 
            models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.models.ToList().AsReadOnly();

        public void AddItem(IWeapon model)
        {
            this.models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return this.models.FirstOrDefault( m => m.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            var model = this.FindByName(name);
            return this.models.Remove(model);
        }
    }
}
