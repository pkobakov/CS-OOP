using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private ICollection<ISupplement> models;
        public SupplementRepository()
        {
            this.models = new List<ISupplement>();
        }
        
     
        
        public void AddNew(ISupplement model)
        {
            this.models.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
           return this.models.FirstOrDefault( i => i.InterfaceStandard  == interfaceStandard);
        }

        public IReadOnlyCollection<ISupplement> Models()
        {
            return this.models.ToList().AsReadOnly();
        }

        public bool RemoveByName(string typeName)
        {
            var model = models.FirstOrDefault(m => m.GetType().Name == typeName);

            return this.models.Remove(model);
        }
    }
}
