using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private ICollection<IHero> heroes;

        public HeroRepository() 
        {
            this.heroes = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => this.heroes.ToList().AsReadOnly();

        public void Add(IHero model)
        {
            this.heroes.Add(model);
        }

        public IHero FindByName(string name)
        {
            return this.heroes.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IHero model)
        {
            IHero hero = this.FindByName(model.Name);
            
            return this.heroes.Remove(hero);
        }
    }
}
