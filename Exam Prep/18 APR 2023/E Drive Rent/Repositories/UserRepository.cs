using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private ICollection<IUser> models;
        public UserRepository() 
        {
             this.models = new List<IUser>();
        }

        public void AddModel(IUser model)
        {
            this.models.Add(model);
        }

        public IUser FindById(string identifier)
        {
            return this.models.FirstOrDefault(m => m.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            return this.models.ToList().AsReadOnly();
        }

        public bool RemoveById(string identifier)
        {
           return this.models.Remove(this.FindById(identifier));
        }
    }
}
