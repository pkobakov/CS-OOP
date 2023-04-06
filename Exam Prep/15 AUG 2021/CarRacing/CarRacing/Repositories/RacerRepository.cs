using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private ICollection<IRacer> models;
        public RacerRepository() 
        {
            models = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => this.models.ToList().AsReadOnly();

        public void Add(IRacer model)
        {
            if (model == null) throw new ArgumentNullException(ExceptionMessages.InvalidAddRacerRepository);
            models.Add(model);
        }

        public IRacer FindBy(string property)
        {
           return models.FirstOrDefault( r => r.Username == property);
        }

        public bool Remove(IRacer model)
        {
            return models.Remove(model);
        }
    }
}
