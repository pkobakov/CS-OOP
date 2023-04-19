using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private ICollection<IBooth> models;
        public BoothRepository()
        {
            this.models = new List<IBooth>();
        }
        public IReadOnlyCollection<IBooth> Models => this.models.ToList().AsReadOnly();

        public void AddModel(IBooth model)
        {
            this.models.Add(model);
        }
    }
}
