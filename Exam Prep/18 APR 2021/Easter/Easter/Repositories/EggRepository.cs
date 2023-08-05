using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly ICollection<IEgg> models;
        public EggRepository() 
        {
            this.models = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => this.models.ToList().AsReadOnly();

        public void Add(IEgg model)
        {
            this.models.Add(model);
        }

        public IEgg FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IEgg model)
        {
            return this.models.Remove(model);
        }
    }
}
