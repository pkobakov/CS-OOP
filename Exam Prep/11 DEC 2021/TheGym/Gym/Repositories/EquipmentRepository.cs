using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private ICollection<IEquipment>  models;
        public EquipmentRepository()
        { 
             models = new List<IEquipment>();   
        }    
        public IReadOnlyCollection<IEquipment> Models => this.models.ToList().AsReadOnly();

        public void Add(IEquipment model)
        {
            models.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return models.FirstOrDefault( m => m.GetType().Name == type);
        }

        public bool Remove(IEquipment model)
        {
            return models.Remove(model);
        }
    }
}
