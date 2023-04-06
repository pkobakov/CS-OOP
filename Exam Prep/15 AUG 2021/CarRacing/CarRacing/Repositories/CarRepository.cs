using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        ICollection<ICar> models;
        public CarRepository() 
        {
            models = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => this.models.ToList().AsReadOnly();

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            this.models.Add(model);
        }

        public ICar FindBy(string property)
        {
            return this.models.FirstOrDefault( c => c.VIN == property);
        }

        public bool Remove(ICar model)
        {
            return models.Remove(model);
        }
    }
}
