using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private ICollection<IDelicacy> models;
        public DelicacyRepository() 
        {
              this.models = new List<IDelicacy>();
        }
        public IReadOnlyCollection<IDelicacy> Models => this.models.ToList().AsReadOnly();

        public void AddModel(IDelicacy model)
        {
            this.models.Add(model);
        }
    }
}
