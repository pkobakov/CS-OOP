using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private ICollection<IVehicle> models;
        public VehicleRepository() 
        {
            this.models = new List<IVehicle>();
        }
        public void AddModel(IVehicle model)
        {
            this.models.Add(model);
        }

        public IVehicle FindById(string identifier)
        {
            return this.models.FirstOrDefault( m => m.LicensePlateNumber == identifier);
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            return this.models.ToList().AsReadOnly();
        }

        public bool RemoveById(string identifier)
        {
          return this.models.Remove(this.FindById(identifier));
        }
    }
}
